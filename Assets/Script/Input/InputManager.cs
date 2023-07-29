using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
using YARG.Core.Input;
using YARG.Player;

namespace YARG.Input
{
    using Enumerate = InputControlExtensions.Enumerate;

    public delegate void MenuInputEvent(YargPlayer player, ref GameInput input);

    public class InputManager : MonoBehaviour
    {
        public const Enumerate DEFAULT_CONTROL_ENUMERATION_FLAGS =
            Enumerate.IgnoreControlsInCurrentState | // Only controls that have changed
            Enumerate.IncludeNoisyControls |         // Constantly-changing controls like accelerometers
            Enumerate.IncludeSyntheticControls;      // Non-physical controls like stick up/down/left/right

        public static event Action<InputDevice> DeviceAdded;
        public static event Action<InputDevice> DeviceRemoved;

        public static event MenuInputEvent MenuInput;

        // Time reference for when inputs started being tracked
        public static double InputTimeOffset { get; set; }

        public static double CurrentUpdateTime { get; private set; }

        // Input events are timestamped directly in the constructor, so we can use them to get the current time
        public static double CurrentInputTime => new InputEvent(StateEvent.Type, 0, InputDevice.InvalidDeviceId).time;

        public static double RelativeInputTime => GetRelativeTime(CurrentUpdateTime);
        public static double RelativeUpdateTime => GetRelativeTime(CurrentInputTime);

        private IDisposable _onEventListener;

        private void Start()
        {
            _onEventListener?.Dispose();
            // InputSystem.onEvent is *not* a C# event, it's a property which is intended to be used with observables
            // In order to unsubscribe from it you *must* keep track of the IDisposable returned at the end
            _onEventListener = InputSystem.onEvent.Call(OnEvent);

            InputSystem.onAfterUpdate += OnAfterUpdate;
            InputSystem.onDeviceChange += OnDeviceChange;
        }

        private void OnDestroy()
        {
            _onEventListener?.Dispose();
            _onEventListener = null;

            InputSystem.onAfterUpdate -= OnAfterUpdate;
            InputSystem.onDeviceChange -= OnDeviceChange;
        }

        public static double GetRelativeTime(double timeFromInputSystem)
        {
            return timeFromInputSystem - InputTimeOffset;
        }

        public static void RegisterPlayer(YargPlayer player)
        {
            player.MenuInput += OnMenuInput;
        }

        public static void UnregisterPlayer(YargPlayer player)
        {
            player.MenuInput -= OnMenuInput;
        }

        private static void OnMenuInput(YargPlayer player, ref GameInput input)
        {
            MenuInput?.Invoke(player, ref input);
        }

        private void OnAfterUpdate()
        {
            CurrentUpdateTime = CurrentInputTime;
        }

        private void OnEvent(InputEventPtr eventPtr)
        {
            // Only take state events
            if (!eventPtr.IsA<StateEvent>() && !eventPtr.IsA<DeltaStateEvent>())
                return;

            var device = InputSystem.GetDeviceById(eventPtr.deviceId);
            foreach (var player in PlayerContainer.Players)
            {
                var profileBinds = player.Bindings;
                if (!profileBinds.ContainsDevice(device))
                    continue;

                profileBinds.ProcessInputEvent(eventPtr);
                break;
            }
        }

        private void OnDeviceChange(InputDevice device, InputDeviceChange change)
        {
            switch (change)
            {
                case InputDeviceChange.Added:
                // case InputDeviceChange.Enabled: // Devices are enabled/disabled when gaining/losing window focus
                case InputDeviceChange.Reconnected:
                    DeviceAdded?.Invoke(device);
                    break;

                case InputDeviceChange.Removed:
                // case InputDeviceChange.Disabled: // Devices are enabled/disabled when gaining/losing window focus
                case InputDeviceChange.Disconnected:
                    DeviceRemoved?.Invoke(device);
                    break;
            }
        }
    }
}
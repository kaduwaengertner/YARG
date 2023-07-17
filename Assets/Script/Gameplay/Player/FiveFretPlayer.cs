﻿using System;
using System.Collections.Generic;
using UnityEngine;
using YARG.Core.Chart;
using YARG.Core.Engine.Guitar;
using YARG.Core.Engine.Guitar.Engines;
using YARG.Core.Input;
using YARG.Input;
using YARG.Player;

namespace YARG.Gameplay
{
    public class FiveFretPlayer : BasePlayer<GuitarEngine, GuitarNote>
    {
        private readonly GuitarEngineParameters _engineParams = new(0.14, 1, 0.08,
            0.065, true);

        public override void Initialize(YargPlayer player, InstrumentDifficulty<GuitarNote> chart)
        {
            base.Initialize(player, chart);

            Engine = new YargFiveFretEngine(Chart.Notes, _engineParams);

            Engine.OnNoteHit += (index, note) =>
            {
                Debug.Log($"[{index} Hit note at " + note.Time);
            };

            // Engine.OnNoteMissed += (index, note) =>
            // {
            //     Debug.Log($"[{index}] Missed note at " + note.Time);
            // };

            Engine.OnOverstrum += () => Debug.Log("Overstrummed");
        }

        protected override void UpdateVisuals()
        {
            UpdateBaseVisuals(Engine.EngineStats);
        }

        protected override void InitializeSpawnedNote(IPoolable poolable, GuitarNote note)
        {
            ((FiveFretVisualNote) poolable).NoteRef = note;
        }

        protected override void SubscribeToInputEvents()
        {
            InputManager.OnGameInput += OnGameInput;
        }

        protected override void UnsubscribeFromInputEvents()
        {
            InputManager.OnGameInput -= OnGameInput;
        }

        private void OnGameInput(YargPlayer player, GameInput input)
        {
            if (player != Player || GameManager.IsReplay)
            {
                return;
            }

            Engine.QueueInput(input);
            AddReplayInput(input);
        }
    }
}
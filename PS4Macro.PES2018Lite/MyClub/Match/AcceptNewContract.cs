﻿using PS4MacroAPI;
using System.Threading;
using System.Collections.Generic;

namespace PS4Macro.PES2018Lite.Match
{
    class AcceptNewContract : Scene
    {
        public override string Name => "Match : Accept New Contract Player/Manager";

        private static RectMap extension = new RectMap()
        {
            ID = "Match-AcceptNewContract-extension.png",
            Width = 1008,
            Height = 729,
            Hash = 68442442891264
        };

        private static RectMap extensionFocusHeader_1player = new RectMap()
        {
            ID = "Match-AcceptNewContract-extensionHeader.png (Y offset = 1 player)",
            X = 255,
            Y = 241,
            Width = 495,
            Height = 90,
            Hash = 28006088003583871
        };

        private static RectMap extensionFocusHeader_2players = new RectMap()
        {
            ID = "Match-AcceptNewContract-extensionHeader.png (Y offset = 2 players)",
            X = 255,
            Y = 229,
            Width = 495,
            Height = 90,
            Hash = 28006088003583871
        };

        private static RectMap extensionFocusHeader_3players = new RectMap()
        {
            ID = "Match-AcceptNewContract-extensionHeader.png (Y offset = 3 players)",
            X = 255,
            Y = 217,
            Width = 495,
            Height = 90,
            Hash = 28006088003583871
        };

        private static RectMap extensionFocusHeader_4players = new RectMap()
        {
            ID = "Match-AcceptNewContract-extensionHeader.png (Y offset = 4 players)",
            X = 255,
            Y = 205,
            Width = 495,
            Height = 90,
            Hash = 28006088003583871
        };

        private static RectMap extensionFocusHeader_5players = new RectMap()
        {
            ID = "Match-AcceptNewContract-extensionHeader.png (Y offset = 5 players)",
            X = 255,
            Y = 193,
            Width = 495,
            Height = 90,
            Hash = 28006088003583871
        };

        private static RectMap extensionFocusHeader_6players = new RectMap()
        {
            ID = "Match-AcceptNewContract-extensionHeader.png (Y offset = 6 players)",
            X = 255,
            Y = 181,
            Width = 495,
            Height = 90,
            Hash = 28006088003583871
        };

        private static RectMap extension2Focus = new RectMap()
        {
            ID = "Match-AcceptNewContract-extension2Focus.png",
            X = 181,
            Y = 464,
            Width = 146,
            Height = 19,
            Hash = 9186919927859150719
        };

        private static RectMap extension3Focus = new RectMap()
        {
            ID = "Match-AcceptNewContract-extension3Focus.png",
            X = 337,
            Y = 377,
            Width = 47,
            Height = 23,
            Hash = 9187131120130015615
        };

        private static RectMap extension4Focus = new RectMap()
        {
            ID = "Match-AcceptNewContract-extension4Focus.png",
            X = 488,
            Y = 366,
            Width = 32,
            Height = 21,
            Hash = 16108853741370846942
        };

        private static RectMap extension5Focus = new RectMap()
        {
            // TODO : CAPTURE THE PICTURE !!
            ID = "Match-AcceptNewContract-extension5Focus.png",
            X = 1,
            Y = 2,
            Width = 1008,
            Height = 729,
            Hash = 68442442891264
        };

        private static RectMap extensionManager = new RectMap()
        {
            ID = "Match-AcceptManagerNewContract-extension.png",
            Width = 1008,
            Height = 729,
            Hash = 26938026426368
        };

        private static RectMap extensionManagerFocusHeader = new RectMap()
        {
            ID = "Match-AcceptManagerNewContract-extensionHeader.png",
            X = 278,
            Y = 289,
            Width = 450,
            Height = 40,
            Hash = 35747869642146625
        };

        public override bool Match(ScriptBase script)
        {
            /* DEBUG */
            Log.LogMatchTemplate(script, Name, new List<RectMap> { extension, extensionFocusHeader_1player, extensionFocusHeader_2players,
                extensionFocusHeader_3players, extensionFocusHeader_4players, extensionFocusHeader_5players, extensionFocusHeader_6players,
                extensionManager, extensionManagerFocusHeader });

            return script.MatchTemplate(extension, 98) && 
                ( script.MatchTemplate(extensionFocusHeader_1player, 98) || script.MatchTemplate(extensionFocusHeader_2players, 98) 
                || script.MatchTemplate(extensionFocusHeader_3players, 98) || script.MatchTemplate(extensionFocusHeader_4players, 98) 
                || script.MatchTemplate(extensionFocusHeader_5players, 98) || script.MatchTemplate(extensionFocusHeader_6players, 98) )
                || script.MatchTemplate(extensionManager, 98) && script.MatchTemplate(extensionManagerFocusHeader, 98);
        }

        public override void OnMatched(ScriptBase script)
        {
            bool manager = script.MatchTemplate(extensionManagerFocusHeader, 98);

            Log.LogMessage(Name, "Start");
            // List of player to renew
            script.Press(new DualShockState() { DPad_Right = true });
            script.Press(new DualShockState() { Cross = true });
            Log.LogMessage(Name, "Accept to renew players/Manager");

            // Cost and kind of money
            while (!script.MatchTemplate(script.CaptureFrame(), extension2Focus, 98))
            {
                Thread.Sleep(1000);
                Log.LogMessage(Name, "Waiting for 'Pay with GP money'");
            }
            script.Press(new DualShockState() { Cross = true });
            Log.LogMessage(Name, "Pay with GP money");

            // Confirmation
            while (!script.MatchTemplate(script.CaptureFrame(), extension3Focus, 98))
            {
                Thread.Sleep(1000);
                Log.LogMessage(Name, "Waiting for 'Confirm'");
            }
            script.Press(new DualShockState() { DPad_Right = true });
            script.Press(new DualShockState() { Cross = true });
            Log.LogMessage(Name, "Confirm");

            // Transaction'status
            while (!script.MatchTemplate(script.CaptureFrame(), extension4Focus, 98))
            {
                Thread.Sleep(1000);
                Log.LogMessage(Name, "Waiting for 'Skip transaction status'");
            }
            script.Press(new DualShockState() { Cross = true });
            Log.LogMessage(Name, "Skip transaction'status");

            /* Only for manager */
            if (manager)
            {
                // Transaction'status 2
                /*while (!script.MatchTemplate(script.CaptureFrame(), extension5Focus, 98))
                {
                    Thread.Sleep(1000);
                    Log.LogMessage(Name, "Waiting for 'Skip transaction status2'");
                }*/
                // TODO : CAPTURE THE PICTURE !!
                Thread.Sleep(5000);
                script.Press(new DualShockState() { Cross = true });
                Log.LogMessage(Name, "Skip transaction'status2");
            }
            Log.LogMessage(Name, "End");
        }
    }
}

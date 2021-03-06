﻿using PS4MacroAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PS4Macro.PES2018Lite
{
    class Log
    {
        private static bool _debug = true; /* false; */
        public enum Level { debug, info, error, critic };
        private static Level _level = Level.debug;
        public static bool Debug() { return _debug; }
        public static void LogMatchTemplate(ScriptBase script, string name, List<RectMap> listRectMap, int similarity = 98)
        {
            if (_debug)
            {
                Console.WriteLine("{0}", name);                     /* to print to the built-in console */
                System.Diagnostics.Debug.WriteLine("{0}", name);    /* to print to "Output" console in Visual Studio. */
                foreach (var item in listRectMap)
                {
                    if (script.MatchTemplate(item, similarity))
                    {
                        if (_level <= Level.info)
                        {
                            Console.WriteLine("\t*** RectMap '{1}' return {2}", name, item.ID, script.MatchTemplate(item, similarity).ToString());                     /* to print to the built-in console */
                            System.Diagnostics.Debug.WriteLine("\t RectMap '{1}' return {2}", name, item.ID, script.MatchTemplate(item, similarity).ToString());    /* to print to "Output" console in Visual Studio. */
                        }
                    }
                    else 
                    {
                        if (_level <= Level.debug)
                        {
                            // Find the similarity 'ok'
                            int s;
                            for (s = 100; s > 0 && !script.MatchTemplate(item, s); --s) { }
                            Console.WriteLine("\t    RectMap '{1}' ok for similarity {2}", name, item.ID, s);                     /* to print to the built-in console */
                            System.Diagnostics.Debug.WriteLine("\t    RectMap '{1}' ok for similarity {2}", name, item.ID, s);    /* to print to "Output" console in Visual Studio. */
                        }
                    }
                }
            }
        }

        public static void LogMatchTemplate(ScriptBase script, string name, List<PixelMap> listPixelMap, int similarity = 98)
        {
            if (_debug)
            {
                Console.WriteLine("{0}", name);                     /* to print to the built-in console */
                System.Diagnostics.Debug.WriteLine("{0}", name);    /* to print to "Output" console in Visual Studio. */
                foreach (var item in listPixelMap)
                {
                    if (script.MatchTemplate(item, similarity))
                    {
                        if (_level <= Level.info)
                        {
                            Console.WriteLine("\t*** PixelMap '{1}' return {2}", name, item.ID, script.MatchTemplate(item, similarity).ToString());                     /* to print to the built-in console */
                            System.Diagnostics.Debug.WriteLine("\tPixelMap '{1}' return {2}", name, item.ID, script.MatchTemplate(item, similarity).ToString());    /* to print to "Output" console in Visual Studio. */
                        }
                    }
                    else
                    {
                        if (_level <= Level.debug)
                        {
                            // Find the similarity 'ok'
                            int s;
                            for (s = 100; s > 0 && !script.MatchTemplate(item, s); s++) { }
                            Console.WriteLine("\t    RectMap '{1}' ok for similarity {2}", name, item.ID, s);                     /* to print to the built-in console */
                            System.Diagnostics.Debug.WriteLine("\t    RectMap '{1}' ok for similarity {2}", name, item.ID, s);    /* to print to "Output" console in Visual Studio. */
                        }
                    }
                }
            }
        }

        public static void LogMessage(string name, string text)
        {
            if (_debug)
            {
                Console.WriteLine("\t* {0} : {1}", name, text);                     /* to print to the built-in console */
                System.Diagnostics.Debug.WriteLine("\t* {0} : {1}", name, text);    /* to print to "Output" console in Visual Studio. */
            }
        }

        public static void Log2File(string name, string text)
        {
            if (_debug)
            {
                try
                {
                    //Open the File
                    StreamWriter sw = new StreamWriter("log.txt", true, Encoding.UTF8);

                    //Writeout the text.
                    sw.WriteLine("[{2}] {0} : {1}", name, text, DateTime.Now.ToString());     /* to print to the log file */
                    Console.WriteLine("\t* {0} : {1}", name, text);                     /* to print to the built-in console */
                    System.Diagnostics.Debug.WriteLine("\t* {0} : {1}", name, text);    /* to print to "Output" console in Visual Studio. */

                    //close the file
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
        }
    }
}

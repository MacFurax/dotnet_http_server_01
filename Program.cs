﻿using System;
using System.Collections.Generic;
using Red;
using Newtonsoft.Json;

namespace list_quickstart
{
   
   class Cue{
        public int id;
        public String name;
        public double duration;
   }

   class RplErraticMasterStatus
   {
       public bool erraticMasterStatus = false;
       public bool showControlStatus = false;
       public bool rideSystemStatus = false;
       //public List<String> latestMessages;

       public RplErraticMasterStatus( bool erraticMasterStatus, bool showControlStatus, bool rideSystemStatus)
       {
           this.erraticMasterStatus = erraticMasterStatus;
           this.showControlStatus= showControlStatus;
           this.rideSystemStatus = rideSystemStatus;
       }
   }

    class Program
    {
        static void Main(string[] args)
        {
            Red.RedHttpServer httpSrv;
            httpSrv = new RedHttpServer(6969, null);
            
            // Using url queries to generate an answer
            httpSrv.Get("/showControl/cues", async (req, res) =>
            {
                List<Cue> cues = new List<Cue>();

                Cue cue = new Cue();
                cue.id = 0;
                cue.name="CUE 000";
                cue.duration = 234;

                cues.Add( cue);

                cue = new Cue();
                cue.id = 1;
                cue.name="CUE 001";
                cue.duration = 187;

                cues.Add( cue);

                cue = new Cue();
                cue.id = 2;
                cue.name="CUE 002";
                cue.duration = 187;

                cues.Add( cue);

                cue = new Cue();
                cue.id = 3;
                cue.name="CUE 003";
                cue.duration = 187;

                cues.Add( cue);

                cue = new Cue();
                cue.id = 4;
                cue.name="CUE 004";
                cue.duration = 187;

                cues.Add( cue);

                cue = new Cue();
                cue.id = 5;
                cue.name="CUE 005";
                cue.duration = 187;

                cues.Add( cue);
                
                cue = new Cue();
                cue.id = 6;
                cue.name="CUE 006";
                cue.duration = 187;

                cues.Add( cue);

                cue = new Cue();
                cue.id = 7;
                cue.name="CUE 007";
                cue.duration = 187;

                cues.Add( cue);

                cue = new Cue();
                cue.id = 8;
                cue.name="CUE 008";
                cue.duration = 187;

                cues.Add( cue);

                // needed to allow request from other domain to be served
                res.AddHeader("Access-Control-Allow-Origin", "*");

                await res.SendString(JsonConvert.SerializeObject(cues));
            });

            httpSrv.Get("/status", async(Request, ResolveEventArgs) =>
            {
                RplErraticMasterStatus reply = new RplErraticMasterStatus(true, false, false );

                // needed to allow request from other domain to be served
                ResolveEventArgs.AddHeader("Access-Control-Allow-Origin", "*");

                await ResolveEventArgs.SendString( JsonConvert.SerializeObject(reply));
            });

            httpSrv.Get("/test", async(Request, ResolveEventArgs) =>
            {
                // needed to allow request from other domain to be served
                ResolveEventArgs.AddHeader("Access-Control-Allow-Origin", "*");

                await ResolveEventArgs.SendString("ErraticMaster:OK");
            });

            // start HTTP server
            httpSrv.Start();
            Console.WriteLine("Press any key to stop.");
            // wait to close app
            Console.ReadKey();
        }

    }
}

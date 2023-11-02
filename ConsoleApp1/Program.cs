// See https://aka.ms/new-console-template for more information
using Raft;
using Serilog;

Console.WriteLine("Hello, World!");

//Log = new Logger();
////tm = new TimeMaster(log);

//if (args.Length > 0)
//{
//    switch (args[0])
//    {
//        case "1":
//            Scenario1(args);
//            return;
//    }
//}


//UdpTester t = new UdpTester(tm, log);
//t.Start(40000);

var dd = new Raft.RaftEmulator.Emulator();
//dd.StartEmulateNodes(5);
dd.StartEmulateTcpNodes(5);



Console.WriteLine("--------");
int val = 0;
while (true)
{
    string cmd = Console.ReadLine();
    switch (cmd)
    {
        case "quit":
            return;
        default:
            try
            {
                string[] spl = cmd.Split(' ');
                if (spl.Count() > 1)
                {
                    switch (spl[0])
                    {
                        case "start": //start 2
                            dd.Start(Convert.ToInt32(spl[1]));
                            break;
                        case "stop": //stop 1
                            dd.Stop(Convert.ToInt32(spl[1]));
                            break;
                        case "test": //sendtestall 4254 - means node 4254 must send to all TcpMsg "Test"
                            dd.SendTestAll(Convert.ToInt32(spl[1]));
                            break;
                        case "set": //set 1 - will create an entity
                            val++;
                            dd.SetValue(new byte[] { (byte)val });
                            break;

                        case "set10": //set10 1 - will create an entity
                            for (int qi = 0; qi < 10; qi++)
                                dd.SetValue(new byte[] { 12 });
                            break;
                    }
                }
                //else if(spl.Count() == 1)
                //{
                //    switch (spl[0])
                //    {                                   
                //        case "testall": //sendtestall 4254 - means node 4254 must send to all TcpMsg "Test"
                //            Console.WriteLine("test 4250");
                //            dd.SendTestAll(4250);

                //            Console.WriteLine("test 4251");
                //            dd.SendTestAll(4251);

                //            Console.WriteLine("test 4252");
                //            dd.SendTestAll(4252);

                //            Console.WriteLine("test 4253");
                //            dd.SendTestAll(4253);

                //            Console.WriteLine("test 4254");
                //            dd.SendTestAll(4254);
                //            break;
                //    }
                //}
                else
                    Console.WriteLine("Unknown command");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }

            break;
    }
}
        

public class Logger : IWarningLog
{
    public void Log(WarningLogEntry logEntry)
    {
        Console.WriteLine(logEntry.ToString());
    }
}


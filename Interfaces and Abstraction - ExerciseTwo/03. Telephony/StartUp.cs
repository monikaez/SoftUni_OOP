
using Telephony.Core.Interfaces;
using Telephony.Core;
using Telephony.IO;

IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
engine.Run();
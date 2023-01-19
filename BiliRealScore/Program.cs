using BiliRealScore;

string md = Console.ReadLine();
RequestData t = new(md);
t.setType(true);
t.getAllData();
t.setType(false);
t.getAllData();
double av = t.getAverage();
Console.WriteLine("score: {0}", av);
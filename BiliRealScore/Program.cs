using BiliRealScore;

string md = "5796";
RequestData t = new(md);
t.setType(true);
t.sleepTime = 500;
t.getAllData();
t.setType(false);
t.getAllData();
double av = t.getAverage();
Console.Clear();
t.showScores();
Console.WriteLine("score: {0}", av);
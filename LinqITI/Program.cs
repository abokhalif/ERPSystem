namespace LinqITI
{

    #region Hashing Code

   
    //class Point
    //{
    //    public int X { get; set; }
    //    public int Y { get; set; }

        
    //    // when adding (key,value) into dictionary the dictionary search by(key) if it is in the stored hashcodes or not if in it search 
    //    // by(value)using (Equals) if it find not added the data if find add the data the data 
    //    public override int GetHashCode()
    //    {
    //        return HashCode.Combine(X, Y);
    //    }
    //    public override bool Equals(object? obj)
    //    {
    //        return obj is Point point &&
    //               X == point.X &&
    //               Y == point.Y;
    //    }
    //    // when modify the object in the run time it can make a collission in the Hashcode because the code based on the values of the object
    //    // so , we make the class is immutable 
    //    public override string ToString()
    //    {
    //        return $"X= {X}, Y= {Y}";
    //    }
    //}

    //class Pointv2
    //{
        
    //    //Dictionary key must be immutable data type , so we cut the way when modify the data of the object cause the key based on vales of the object
    //    // no way to change object state ,the creating new object with new state and new Identity
    //    int X { get;  }
    //   int Y { get; }
    //    public Pointv2(int x,int y)
    //    {
    //        X = x;
    //        Y = y;
    //    }
    //    public override int GetHashCode()
    //    {
    //        return HashCode.Combine(X, Y);
    //    }
    //    public override bool Equals(object? obj)
    //    {
    //        return obj is Point point &&
    //               X == point.X &&
    //               Y == point.Y;
    //    }
    //    public override string ToString()
    //    {
    //        return $"X= {X}, Y= {Y}";
    //    }

    //}

    //    internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Point p1 = new Point() { X = 1, Y = 1 };
    //        Point p2 = new Point() { X = 2, Y = 2 };
    //        Point p3 = new Point() { X = 3, Y = 3 };
    //        Point p4 = new Point() { X = 1, Y = 1 };
    //        Point p5 = p1;

    //        // Default GetHashCode() => return object Identity . value based on object Identity
    //        // before adding val in dictionary it check the HashCodes if it doesnot find add the new record
    //        // if find HashCode check the values of the records if Equals to last values doesnot add it (it exist) if not equal add the record(Defult)
    //        Dictionary<Point,string> dic= new Dictionary<Point,string>();
    //        dic.Add(p1,"LeftCorner");
    //        dic.Add(p2, "RightCorner");

    //        dic.Add(p3, "TopEdge");// -1186707760

    //        if (dic.TryAdd(p4, "LeftCorner2"))
    //            Console.WriteLine("P4 added");
    //        else Console.WriteLine("P4 already exist");

    //        if (dic.TryAdd(p5, "LeftCorner2"))
    //            Console.WriteLine("P5 added");
    //        else Console.WriteLine("P5 already exist");  

    //        //p3= new Point() { X = 10, Y = 10};// to modify record in dictionary u must Remove it and add the new after modification
    //        //Console.WriteLine(p3.GetHashCode());//35191196 // p3 changed HashCode , old value lost inside the dictionary

    //        dic.Remove(p3);
    //        p3 = new Point() { X = 10, Y = 10 };
    //        dic.Add(p3,"TopEdge");// -1186707760

    //        foreach (var item in dic)
    //        {
    //            Console.WriteLine($"{item.Key} : {item.Value}");
    //        }

    //        Console.WriteLine();
    //        foreach (var item in dic)
    //        {
    //            Console.WriteLine($"{item.Key.ToString()} :: {item.GetHashCode()}");
    //        }


    //    }

    //}
    #endregion
}
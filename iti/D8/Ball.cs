using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D8
{
    // 1- publisher class
    internal class Ball
    {
        public int Id { get; set; }
        Location bLocation;
        public Location BallLocation 
        { 
            get => bLocation;
            /*v01
             * set 
            {
                if (value != bLocation)
                {
                    bLocation = value;
                    //3- Notify subscriber{fire}
                    // if delegete is return type (func) in the innvocation list will assign valueof the last function in the list to the return variable
                    BallLocationChanged?.Invoke();// loop through Innvocation list
                                                  // call subescriber call back method
                }
            } */

            //v2
            set
            {
                if (value != bLocation)
                {
                    bLocation = value;
                    //3- Notify subscriber{fire}
                    // if delegete is return type (func) in the innvocation list will assign valueof the last function in the list to the return variable
                    BallLocationChanged?.Invoke(bLocation); // loop through Innvocation list
                                                       // call subescriber call back method
                }
            }
        }

        // 2- Event Declaration
        // v01
        //public event Action? BallLocationChanged;  // event => to prevent using the assign(=) it use only (+= | -=) 

        //v02
        public event Action<Location>? BallLocationChanged;// argument event
        public override string ToString()
        {
            return $"Ball {Id} @ {bLocation}";
        }

    }
}

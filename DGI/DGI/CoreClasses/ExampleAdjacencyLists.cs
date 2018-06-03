using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGI.CoreClasses
{
    public static class ExampleAdjacencyLists
    {
        /// <summary>
        /// Statyczne listy do pobierania w celach testowania głównego programu 
        /// Konwencja nazewnictwa na przykładzie "lista4_a1":
        /// lista4 - lista sąsiedztwa z 4 wierzchołkami
        /// _5_ - wskazuje na ilość krawędzi
        /// _a1 - literka po _ wskazuje listy o tej samej ilości wierzchołków, ktore powinny być do siebie bijektywne. 
        ///         Cyfra jest porządkowa, aby zapobiec powtarzaniu się nazw
        /// </summary>
        
        public static List<List<int>> lista4_5_a1 { get; private set; }
        public static List<List<int>> lista4_5_a2 { get; private set; }

        public static List<List<int>> lista4_6_a1 { get; private set; }
        public static List<List<int>> lista4_6_a2 { get; private set; }
        public static List<List<int>> lista4_6_b1 { get; private set; }

        public static List<List<int>> lista6_7_a1 { get; private set; }
        public static List<List<int>> lista6_7_a2 { get; private set; }
        public static List<List<int>> lista6_7_b1 { get; private set; }

        public static List<List<int>> lista9_9_a1 { get; private set; }
        public static List<List<int>> lista9_9_a2 { get; private set; }

        public static List<List<int>> lista45_70_a1 { get; private set; }
        public static List<List<int>> lista44_70_a2 { get; private set; }


        static ExampleAdjacencyLists()
        {
            #region 4 wierzchołki
            lista4_5_a1 = new List<List<int>>();
            lista4_5_a1.Add(new List<int>());
            lista4_5_a1.Add(new List<int>());
            lista4_5_a1.Add(new List<int>());
            lista4_5_a1.Add(new List<int>());
            lista4_5_a1[0].Add(1);
            lista4_5_a1[0].Add(3);
            lista4_5_a1[1].Add(2);
            lista4_5_a1[2].Add(0);
            lista4_5_a1[3].Add(2);

            lista4_5_a2 = new List<List<int>>();
            lista4_5_a2.Add(new List<int>());
            lista4_5_a2.Add(new List<int>());
            lista4_5_a2.Add(new List<int>());
            lista4_5_a2.Add(new List<int>());
            lista4_5_a2[0].Add(1);
            lista4_5_a2[1].Add(2);
            lista4_5_a2[2].Add(0);
            lista4_5_a2[2].Add(3);
            lista4_5_a2[3].Add(1);

            lista4_6_a1 = new List<List<int>>();
            lista4_6_a1.Add(new List<int>());
            lista4_6_a1.Add(new List<int>());
            lista4_6_a1.Add(new List<int>());
            lista4_6_a1.Add(new List<int>());
            lista4_6_a1[0].Add(2);
            lista4_6_a1[0].Add(4);
            lista4_6_a1[1].Add(3);
            lista4_6_a1[2].Add(1);
            lista4_6_a1[2].Add(4);
            lista4_6_a1[3].Add(2);

            lista4_6_a2 = new List<List<int>>();
            lista4_6_a2.Add(new List<int>());
            lista4_6_a2.Add(new List<int>());
            lista4_6_a2.Add(new List<int>());
            lista4_6_a2.Add(new List<int>());
            lista4_6_a2[0].Add(2);
            lista4_6_a2[1].Add(3);
            lista4_6_a2[1].Add(4);
            lista4_6_a2[2].Add(1);
            lista4_6_a2[3].Add(1);
            lista4_6_a2[3].Add(3);

            lista4_6_b1 = new List<List<int>>();
            lista4_6_b1.Add(new List<int>());
            lista4_6_b1.Add(new List<int>());
            lista4_6_b1.Add(new List<int>());
            lista4_6_b1.Add(new List<int>());
            lista4_6_b1[0].Add(2);
            lista4_6_b1[0].Add(3);
            lista4_6_b1[1].Add(3);
            lista4_6_b1[2].Add(1);
            lista4_6_b1[2].Add(4);
            lista4_6_b1[3].Add(2);
            #endregion

            #region 6 wierzchołków
            lista6_7_a1 = new List<List<int>>();
            lista6_7_a1.Add(new List<int>());
            lista6_7_a1.Add(new List<int>());
            lista6_7_a1.Add(new List<int>());
            lista6_7_a1.Add(new List<int>());
            lista6_7_a1.Add(new List<int>());
            lista6_7_a1.Add(new List<int>());
            lista6_7_a1[0].Add(3);
            lista6_7_a1[1].Add(1);
            lista6_7_a1[1].Add(4);
            lista6_7_a1[2].Add(4);
            lista6_7_a1[2].Add(5); // 5
            lista6_7_a1[4].Add(2);
            lista6_7_a1[4].Add(6);

            lista6_7_a2 = new List<List<int>>();
            lista6_7_a2.Add(new List<int>());
            lista6_7_a2.Add(new List<int>());
            lista6_7_a2.Add(new List<int>());
            lista6_7_a2.Add(new List<int>());
            lista6_7_a2.Add(new List<int>());
            lista6_7_a2.Add(new List<int>());
            lista6_7_a2[1].Add(3);
            lista6_7_a2[2].Add(4);
            lista6_7_a2[2].Add(6);
            lista6_7_a2[3].Add(1);
            lista6_7_a2[3].Add(5); // 5
            lista6_7_a2[4].Add(2);
            lista6_7_a2[4].Add(6);

            lista6_7_b1 = new List<List<int>>();
            lista6_7_b1.Add(new List<int>());
            lista6_7_b1.Add(new List<int>());
            lista6_7_b1.Add(new List<int>());
            lista6_7_b1.Add(new List<int>());
            lista6_7_b1.Add(new List<int>());
            lista6_7_b1.Add(new List<int>());
            lista6_7_b1[1].Add(3);
            lista6_7_b1[2].Add(4);
            lista6_7_b1[2].Add(5);
            lista6_7_b1[4].Add(2);
            lista6_7_b1[4].Add(6); // 5
            lista6_7_b1[5].Add(1);
            lista6_7_b1[5].Add(4);
            #endregion

            #region 9 wierzchołków

            lista9_9_a1 = new List<List<int>>();
            lista9_9_a1.Add(new List<int>());
            lista9_9_a1.Add(new List<int>());
            lista9_9_a1.Add(new List<int>());
            lista9_9_a1.Add(new List<int>());
            lista9_9_a1.Add(new List<int>()); // 5
            lista9_9_a1.Add(new List<int>());
            lista9_9_a1.Add(new List<int>());
            lista9_9_a1.Add(new List<int>());
            lista9_9_a1.Add(new List<int>());
            lista9_9_a1[0].Add(4);
            lista9_9_a1[0].Add(5);
            lista9_9_a1[1].Add(0);
            lista9_9_a1[1].Add(5);
            lista9_9_a1[1].Add(6); // 5
            lista9_9_a1[2].Add(1);
            lista9_9_a1[2].Add(5);
            lista9_9_a1[2].Add(6);
            lista9_9_a1[8].Add(3);

            lista9_9_a2 = new List<List<int>>();
            lista9_9_a2.Add(new List<int>());
            lista9_9_a2.Add(new List<int>());
            lista9_9_a2.Add(new List<int>());
            lista9_9_a2.Add(new List<int>());
            lista9_9_a2.Add(new List<int>()); // 5
            lista9_9_a2.Add(new List<int>());
            lista9_9_a2.Add(new List<int>());
            lista9_9_a2.Add(new List<int>());
            lista9_9_a2.Add(new List<int>());
            lista9_9_a2[1].Add(8);
            lista9_9_a2[2].Add(0);
            lista9_9_a2[2].Add(4);
            lista9_9_a2[2].Add(6);
            lista9_9_a2[4].Add(0); // 5
            lista9_9_a2[4].Add(6);
            lista9_9_a2[4].Add(7);
            lista9_9_a2[7].Add(3);
            lista9_9_a2[7].Add(6);
            #endregion

            #region 45 wierzchołków
            lista45_70_a1 = new List<List<int>>();
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>()); // 5
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>()); // 10
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>()); // 15
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>()); // 20
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>()); // 25
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>()); // 30
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>()); // 35
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>()); // 40
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>());
            lista45_70_a1.Add(new List<int>()); // 45
            lista45_70_a1[0].Add(9);
            lista45_70_a1[0].Add(10);
            lista45_70_a1[1].Add(0);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[2].Add(11);
            lista45_70_a1[3].Add(11);
            lista45_70_a1[4].Add(11);
            lista45_70_a1[4].Add(11);
            lista45_70_a1[4].Add(11);
            lista45_70_a1[4].Add(11);
            lista45_70_a1[5].Add(11);
            lista45_70_a1[6].Add(11);
            lista45_70_a1[7].Add(11);
            lista45_70_a1[8].Add(11);
            lista45_70_a1[9].Add(11);
            lista45_70_a1[9].Add(11);
            lista45_70_a1[10].Add(11);
            lista45_70_a1[10].Add(11);
            lista45_70_a1[11].Add(11);
            lista45_70_a1[11].Add(11);
            lista45_70_a1[12].Add(11);
            lista45_70_a1[12].Add(11);
            lista45_70_a1[13].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);
            lista45_70_a1[1].Add(11);


            #endregion
        }

    }
}

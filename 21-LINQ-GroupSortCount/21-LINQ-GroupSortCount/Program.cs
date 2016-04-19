using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_LINQ_GroupSortCount
{
    class Program
    {
        static void Main(string[] args)
        {
            SentenceParsing("LINQ can be used to group words and count them too");
            Console.ReadLine();
        }



        public static void SentenceParsing(string sentence)
        {
            // Split the string into individual words to create a collection.
            string[] words = sentence.Split(' ');


            // LINQ query
            var query =
                        from w in words // for all the words
                        group w by w.Length into grp // group them by length 
                        orderby grp.Key // order by length 


                        select new
                                        { // create a new object with the required props
                                            Length = grp.Key,
                                            Words = grp,
                                            WordCount = grp.Count()
                                        };

            // execute the query
            foreach (var obj in query)
            {
                Console.WriteLine("Words of length: {0}, Count: {1}",
                    obj.Length, obj.WordCount);

                foreach (string word in obj.Words)
                    Console.WriteLine(word);
            }
        }
    }
}

namespace MediAPIr.Cqrs
{
    using System;
    using System.Collections.Generic;
    using System.Collections;

    public class Data : IEnumerable<Rapper>
    {
        public IEnumerator<Rapper> GetEnumerator()
        {
            var data = new []
            {
                new Rapper { Born = new DateTime(1976, 5, 5), Id = 0, Name = "Aesop Rock", RealName = "Ian Matthias Bavitz" }, 
                new Rapper { Born = new DateTime(1977, 6, 30), Id = 1, Name = "Brother Ali", RealName = "Ali Douglas Newman" },
                new Rapper { Born = new DateTime(1976, 12, 10), Id = 2, Name = "Evidence", RealName = "Michael Taylor Perretta" }
            };

            for (int i = 0; i < data.Length; i++)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

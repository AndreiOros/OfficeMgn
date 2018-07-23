using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace AccesaEmployee
{
	public abstract class Employee
	{
		private string _name;
		private EmployeePosition _position;
		private float _capacity;//max number of hours per day
		private List<string> h1=new List<string>();
        private string hobbie;

        public string Name => _name;
		public EmployeePosition Position => _position;
		public float Capacity => _capacity;
		public List<string> Hobbies => h1;

		protected Employee(string name, EmployeePosition position, float capacity)
		{
			_name = name;
			_position = position;
			_capacity = capacity;
		}

		public virtual void DisplayInfo()
		{
			var sb= new StringBuilder();
			h1.ForEach(x=>sb.Append(x+" "));
			Console.WriteLine($"{_name} ocupa pozitia {_position} si e angajat cu {_capacity} ore pe zi. Lui ii place {sb.ToString()}");
		}

        public Employee(XmlReader r) { ReadXML(r); }

        public virtual void ReadXML(XmlReader r)
        {
            r.ReadStartElement();
            _name = r.ReadElementContentAsString("Name", " ");
            _capacity = r.ReadElementContentAsFloat("capacity", "");
            //_position = r.ReadElementContentAsObject("Position: ", "");
            foreach (string h in Hobbies)
            {
                r.ReadElementContentAsString("Hobbies:", "");
            }
            r.ReadEndElement();
        }

        public virtual void WriteXML(XmlWriter w)
        {
            w.WriteElementString("Name", _name.Trim());
            w.WriteElementString("Capacity", XmlConvert.ToString(Capacity));
           // w.WriteElementString("Position", XmlConvert.ToString(Position));
            foreach (string i in Hobbies)
            {
                w.WriteElementString("Hobby", i);
            }
        }
    }
}

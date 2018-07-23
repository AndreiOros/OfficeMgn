using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AccesaEmployee
{
	public class Intern:Employee
	{
		private string _universityName;
		private int _yearOfStudy;
		private EmployeePosition _targetPosition;

		public string UniversityName => _universityName;
		public int YearOfStudy => _yearOfStudy;
		public EmployeePosition TargetPosition => _targetPosition;
		public Intern(string name, float capacity) 
			: base(name, EmployeePosition.Intern, capacity)
		{}

        public override void ReadXML(XmlReader r)
        {
            base.ReadXML(r);
            _universityName = r.ReadElementContentAsString("UniversityName:", "");
            _yearOfStudy = r.ReadElementContentAsInt("YearOfStudy", "");
        }

        public override void WriteXML(XmlWriter w)
        {
            base.WriteXML(w);
            w.WriteElementString("UniversityName", _universityName);
            w.WriteElementString("YearOfStudy", _yearOfStudy.ToString());
        }

    }
}

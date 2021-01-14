using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using APIDAL;
using DO;

namespace DL
{
    class TempClass:IDAL
    {
        public LineTrip GetLineTripBy(Predicate<LineTrip> predicate)
        {
            XElement lineTripElement = XMLTools.LoadListFromXMLElement(LineTripsPath);
            return (from item in lineTripElement.Elements()
                    let lineTrip = new LineTrip()
                    {
                        LineId = Int32.Parse(item.Element("LineId").Value),
                        NumLine = Int32.Parse(item.Element("NumLine").Value),
                        StartAt = TimeSpan.Parse(item.Element("StartAt").Value),
                        EndAt = TimeSpan.Parse(item.Element("EndAt").Value),
                        Frequency = Int32.Parse(item.Element("Frequency").Value),
                    }
                    where predicate(lineTrip)
                    select lineTrip).FirstOrDefault();
        }
      
        public void AddLineTrip(LineTrip lineTrip)
        {
            XElement lineTripElement = XMLTools.LoadListFromXMLElement(LineTripsPath);
            //XElement linetrip=(from item in lineTripElement.Elements()
            //                   where int.Parse(item.Element("ID").Value)==lin)
            XElement lineTripEl = new XElement("LineTrip",
                new XElement("Id", lineTrip.Id),
                new XElement("LineId", lineTrip.LineId),
                new XElement("NumLine", lineTrip.NumLine),
                new XElement("StartAt", lineTrip.StartAt),
                new XElement("EndAt", lineTrip.EndAt),
                new XElement("Frequency", lineTrip.Frequency));
            lineTripElement.Add(lineTripEl);
            XMLTools.SaveListToXMLElement(lineTripElement, LineTripsPath);
        }

       
        public void AddPerson(DO.Person person)
        {
            XElement personsRootElem = XMLTools.LoadListFromXMLElement(personsPath);

            XElement per1 = (from p in personsRootElem.Elements()
                             where int.Parse(p.Element("ID").Value) == person.ID
                             select p).FirstOrDefault();

            if (per1 != null)
                throw new DO.BadPersonIdException(person.ID, "Duplicate person ID");

            XElement personElem = new XElement("Person",
                                   new XElement("ID", person.ID),
                                   new XElement("Name", person.Name),
                                   new XElement("Street", person.Street),
                                   new XElement("HouseNumber", person.HouseNumber.ToString()),
                                   new XElement("City", person.City),
                                   new XElement("BirthDate", person.BirthDate),
                                   new XElement("PersonalStatus", person.PersonalStatus.ToString()));

            personsRootElem.Add(personElem);

            XMLTools.SaveListToXMLElement(personsRootElem, personsPath);
        }

    }
}
}

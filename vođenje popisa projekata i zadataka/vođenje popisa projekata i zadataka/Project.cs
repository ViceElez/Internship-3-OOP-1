using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vođenje_popisa_projekata_i_zadataka
{

    public class Project
    {
        private string _nameOfProject, _descriptionOfProject, _statusOfProject;
        private DateTime _startDateOfProject, _endDateOfProject;

        public Project(string nameOfProject, string descriptionOfProject, string statusOfProject, DateTime startDateOfProject, DateTime endDateOfProject)
        {
            this._nameOfProject = nameOfProject;
            this._descriptionOfProject = descriptionOfProject;
            this._statusOfProject = statusOfProject;
            this._startDateOfProject = startDateOfProject;
            this._endDateOfProject = endDateOfProject;
        }

        public Project()
        {
            Console.Write("Upisite ime projekta:");
            _nameOfProject = Console.ReadLine();
            Console.Write("Upisite opis projekta:");
            _descriptionOfProject = Console.ReadLine();
            Console.Write("Upisite status projekta(aktivan/završen/na čekanju):");
            _statusOfProject = Console.ReadLine();
            while (_statusOfProject.ToLower() != "aktivan" || _statusOfProject.ToLower() != "završen" || _statusOfProject.ToLower() != "na čekanju")
            {
                  Console.WriteLine("Status projekta može biti samo aktivan,završen ili na čekanju.");
                  Console.Write("Upisite status projekta:");
                  _statusOfProject = Console.ReadLine();

            }
            Console.Write("Upisite datum početka projekta:");
            var isStartDateValid = DateTime.TryParse(Console.ReadLine(), out _startDateOfProject);
            while (!isStartDateValid)
            {
                Console.WriteLine("Datum nije u ispravnom formatu.");
                Console.Write("Upisite datum početka projekta:");
                isStartDateValid = DateTime.TryParse(Console.ReadLine(), out _startDateOfProject);
            }
            Console.WriteLine("Upisite datum završetka projekta:");
            var isEndDateValid = DateTime.TryParse(Console.ReadLine(), out _endDateOfProject);
            while (!isEndDateValid)
            {
                Console.WriteLine("Datum nije u ispravnom formatu.");
                Console.Write("Upisite datum završetka projekta:");
                isEndDateValid = DateTime.TryParse(Console.ReadLine(), out _endDateOfProject);
            }

        }

        public string NameOfProject
        {
            get { return _nameOfProject; }
            set { _nameOfProject = value; }
        }
        public string DescriptionOfProject
        {
            get { return _descriptionOfProject; }
            set { _descriptionOfProject = value; }
        }
        public string StatusOfProject
        {
            get { return _statusOfProject; }
            set { _statusOfProject = value; }
        }
        public DateTime StartDateOfProject
        {
            get { return _startDateOfProject; }
            set { _startDateOfProject = value; }
        }
        public DateTime EndDateOfProject
        {
            get { return _endDateOfProject; }
            set { _endDateOfProject = value; }
        }
    }
}

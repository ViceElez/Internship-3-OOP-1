using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vođenje_popisa_projekata_i_zadataka
{
    public class Task
    {
        private string _nameOfTask, _descriptionOfTask, _statusOfTask, _projectItBelongsTo;
        private DateTime _mandatoryEndDateOfTask;
        private int _excpetedMinutesToFinishTask;

        public Task(string nameOfTask, string descriptionOfTask, string statusOfTask, string projectItBelongsTo, DateTime mandatoryEndDateOfTask, int excpetedMinutesToFinishTask)
        {
            this._nameOfTask = nameOfTask;
            this._descriptionOfTask = descriptionOfTask;
            this._statusOfTask = statusOfTask;
            this._projectItBelongsTo = projectItBelongsTo;
            this._mandatoryEndDateOfTask = mandatoryEndDateOfTask;
            this._excpetedMinutesToFinishTask = excpetedMinutesToFinishTask;
        }

        public Task()
        {
            Console.Write("Upisite ime zadatka:");
            _nameOfTask = Console.ReadLine();
            Console.Write("Upisite opis zadatka:");
            _descriptionOfTask = Console.ReadLine();
            Console.Write("Upisite status zadatka(aktivan/završen/na čekanju):");
            _statusOfTask = Console.ReadLine();
            while (_statusOfTask.ToLower() != "aktivan" || _statusOfTask.ToLower() != "završen" || _statusOfTask.ToLower() != "na čekanju")
            {
                Console.WriteLine("Status zadatka može biti samo aktivan,završen ili na čekanju.");
                Console.Write("Upisite status zadatka:");
                _statusOfTask = Console.ReadLine();

            }
            Console.Write("Upisite datum završetka zadatka:");
            var isEndDateValid = DateTime.TryParse(Console.ReadLine(), out _mandatoryEndDateOfTask);
            while (!isEndDateValid)
            {
                Console.WriteLine("Datum nije u ispravnom formatu.");
                Console.Write("Upisite datum završetka zadatka:");
                isEndDateValid = DateTime.TryParse(Console.ReadLine(), out _mandatoryEndDateOfTask);
            }
            Console.Write("Upisite očekivano trajanje zadatka u minutama:");
            var isMinutesValid = int.TryParse(Console.ReadLine(), out _excpetedMinutesToFinishTask);
            while (!isMinutesValid)
            {
                Console.WriteLine("Unesite broj u minutama.");
                Console.Write("Upisite očekivano trajanje zadatka u minutama:");
                isMinutesValid = int.TryParse(Console.ReadLine(), out _excpetedMinutesToFinishTask);
            }
            Console.Write("Upisite projekt kojem pripada zadatak:");
            _projectItBelongsTo = Console.ReadLine();

        }

        public string NameOfTask
        {
            get { return _nameOfTask; }
            set { _nameOfTask = value; }
        }
        public string DescriptionOfTask
        {
            get { return _descriptionOfTask; }
            set { _descriptionOfTask = value; }
        }
        public string StatusOfTask
        {
            get { return _statusOfTask; }
            set { _statusOfTask = value; }
        }
        public string ProjectItBelongsTo
        {
            get { return _projectItBelongsTo; }
            set { _projectItBelongsTo = value; }
        }
        public DateTime MandatoryEndDateOfTask
        {
            get { return _mandatoryEndDateOfTask; }
            set { _mandatoryEndDateOfTask = value; }
        }
        public int ExcpetedMinutesToFinishTask
        {
            get { return _excpetedMinutesToFinishTask; }
            set { _excpetedMinutesToFinishTask = value; }
        }


    }
}

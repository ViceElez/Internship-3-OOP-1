using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vođenje_popisa_projekata_i_zadataka
{
    public class Task
    {
        private string _nameOfTask, _descriptionOfTask, _statusOfTask, _projectItBelongsTo, _priorityOfTask;
        private DateTime _mandatoryEndDateOfTask;
        private float _excpetedMinutesToFinishTask;

        public Task(string nameOfTask, string descriptionOfTask, string statusOfTask,string priorityOfTask, string projectItBelongsTo, DateTime mandatoryEndDateOfTask, float excpetedMinutesToFinishTask)
        {
            this._nameOfTask = nameOfTask;
            this._descriptionOfTask = descriptionOfTask;
            this._statusOfTask = statusOfTask;
            this.PriorityOfTask = priorityOfTask;
            this._projectItBelongsTo = projectItBelongsTo;
            this._mandatoryEndDateOfTask = mandatoryEndDateOfTask;
            this._excpetedMinutesToFinishTask = excpetedMinutesToFinishTask;
        }

        public Task(string nameOfTask, string projectTaskBelongsTo)
        {
            _nameOfTask = nameOfTask;   
            while (string.IsNullOrEmpty(_nameOfTask))
            {
                Console.WriteLine("Ime zadatka ne može biti prazno.");
                Console.Write("Upisite ime zadatka:");
                _nameOfTask = Console.ReadLine();
            }
            Console.Write("Upisite opis zadatka:");
            _descriptionOfTask = Console.ReadLine();
            Console.Write("Upisite status zadatka(aktivan/završen/na čekanju):");
            _statusOfTask = Console.ReadLine();
            while (true)
            {
                if (_statusOfTask.ToLower() == "aktivan" || _statusOfTask.ToLower() == "zavrsen" || _statusOfTask.ToLower() == "na cekanju")
                    break;
                else
                {
                    Console.WriteLine("Status zadatka može biti samo aktivan,zavrsen ili na cekanju.");
                    Console.Write("Upisite status zadatka:");
                    _statusOfTask = Console.ReadLine();
                    continue;
                }
            }
            Console.Write("Upisite prioritet zadatka(visko/srednji/niski):");
            _priorityOfTask = Console.ReadLine();
            while (true)
            {
                if (_priorityOfTask.ToLower() == "visok" || _priorityOfTask.ToLower() == "srednji" || _priorityOfTask.ToLower() == "niski")
                    break;
                else
                {
                    Console.WriteLine("Prioritet zadatka može biti samo visok,srednji ili niski.");
                    Console.Write("Upisite prioritet zadatka:");
                    _priorityOfTask = Console.ReadLine();
                    continue;
                }
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
            var isMinutesValid = float.TryParse(Console.ReadLine(), out _excpetedMinutesToFinishTask);
            while (!isMinutesValid)
            {
                Console.WriteLine("Unesite broj u minutama.");
                Console.Write("Upisite očekivano trajanje zadatka u minutama:");
                isMinutesValid = float.TryParse(Console.ReadLine(), out _excpetedMinutesToFinishTask);
            }
            _projectItBelongsTo = projectTaskBelongsTo;
            while(string.IsNullOrEmpty(_projectItBelongsTo))
            {
                Console.WriteLine("Ime projekta ne može biti prazno.");
                Console.Write("Upisite ime projekta:");
                _projectItBelongsTo = Console.ReadLine();
            }

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
        public string PriorityOfTask
        {
            get { return _priorityOfTask; }
            set { _priorityOfTask = value; }
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
        public float ExcpetedMinutesToFinishTask
        {
            get { return _excpetedMinutesToFinishTask; }
            set { _excpetedMinutesToFinishTask = value; }
        }


    }
}

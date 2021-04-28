using DataBaseOP.Database.Entities;
using System;
using System.Data;
using System.Windows.Forms;

namespace DataBaseOP.Controllers
{
    class WorkerController : BaseController
    {
        public void Add(Worker worker)
        {
            Context.AddWorker(worker);
        }

        public void Edit(Worker worker)
        {
            Context.EditWorker(worker);
        }

        public void Delete(int workerId)
        {
            Context.Delete(workerId, "sp_DeleteWorker");
        }

        public void GetAllWorkers(ref DataGridView dataGridView)
        {
            dataGridView.DataSource = Context.GetAllWorkers();
        }

        public int GetWorkerIdByPhone(string workerPhone)
        {
            return Context.GetWorkerIdByPhone(workerPhone);
        }

        public Worker GetWorkerInfoByPhone(string workerPhone)
        {
            DataTable clientInfo = Context.GetWorkerInfoByPhone(workerPhone);

            Worker worker = new Worker()
            {
                FIO = clientInfo.Rows[0][0].ToString(),
                Position = new Position { Name = clientInfo.Rows[0][1].ToString() },
                Phone = workerPhone
            };

            return worker;
        }
    }
}

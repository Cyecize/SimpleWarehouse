﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouse.Factory;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.RevenueRelated.View;
using SimpleWarehouse.Services.RevenueRelated;

namespace SimpleWarehouse.Presenter.RevenueRelated
{
    public class InvoicesPresenter : AbstractPresenter, IRevenuePresenter
    {
        public IRevenueView Form { get; set; }
        public IAddEntitySection AddEntitySection { get; set; }
        public IArchivedEntitiesSection ArchivedEntitiesSection { get; set; }

        public InvoicesPresenter(IStateManager manager) : base(manager)
        {
            this.Form = (IRevenueView)FormFactory.CreateForm("RevenueForm", new object[] { this });
            ((Form)this.Form).FormClosing += (sen, ev) => this.GoBackAction();
            this.Form.Text = "Фактури";

            this.AddEntitySection = new AddInvoiceSection(this);
            this.ArchivedEntitiesSection = new ArchivedInvoicesSection(this);
            this.AddEntitySection.UpdateNonRevisedEntities();
        }

        public override void Dispose()
        {
            foreach (var id in base.EventIds)
            {
                base.StateManager.EventManager.RemoveEvent(id);
            }
            this.Form.HideAndDispose();
            base.StateManager.OutputWriter.WriteLine("Invoice Presenter Disposed!");
        }

        public override void Update()
        {
            if (!base.IsFormShown)
            {
                this.Form.Show();
                base.IsFormShown = true;
            }
        }

        public void GoBackAction()
        {
            if (base.StateManager.IsPresenterActive(this))
                base.StateManager.Set(new HomePresenter(base.StateManager));
        }
    }
}

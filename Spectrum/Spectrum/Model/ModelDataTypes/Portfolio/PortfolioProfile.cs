using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class PortfolioProfile : BaseEntity
    {
        public int PortfolioID { get; set; }
        public Guid AccountID { get; set; }
        public Guid? CompanyID { get; set; }
        public int WorkspaceID { get; set; }
        public int WorkflowID { get; set; }
        public int ModuleID { get; set; }
        public int TeamID { get; set; }
        public Int64 ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int LanguageID { get; set; }
        public int PortfolioCategoryID { get; set; }
        public string PortfolioName { get; set; }
        public string PortfolioDescription { get; set; }
        public Guid? PortfolioLeadID { get; set; }
        public string PortfolioLeadName { get; set; }
        public string PortfolioOwnerName { get; set; }
        public Guid PortfolioOwnerID { get; set; }
        public string PortfolioKey { get; set; }
        public int PortfolioStartingNumber { get; set; }
        public int PortfolioTypeID { get; set; }
        public int PortfolioStatusID { get; set; }
        public decimal PortfolioPercentDone { get; set; }
        public decimal ProjectPercetage { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal ProjectCost { get; set; }
        public decimal CostToDate { get; set; }
        public int BenefitsRating { get; set; }
        public int RisksRating { get; set; }
        public int BudgetStatusID { get; set; }
        public DateTime PortfolioStartDate { get; set; }
        public DateTime PortfolioEndDate { get; set; }
        public string ReturnMessage { get; set; }
        public int TotalProject { get; set; }
        public bool Active { get; set; }
        public CustomMessage CustomMessage = new CustomMessage();
        public List<ProjectListProfile> ProjectList = new List<ProjectListProfile>();
        public List<int> SelectedPortfolioItem = new List<int>();
        public string LeaderName { get; set; }
        public string UserName { get; set; }
        public string PortfolioManagerImage { get; set; }
        public string PortfolioOwnerImage { get; set; }
        public string StatusName { get; set; }
        public bool IsPortfolioWorkspace { get; set; }
    }
}

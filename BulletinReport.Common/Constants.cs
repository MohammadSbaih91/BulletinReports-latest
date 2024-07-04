namespace BulletinReport.Common
{
    public class Constants
    {
        public class Claims
        {
            public const string ID = "ID";
            public const string UserName = "UserName";
            public const string AccountTypeId = "AccountTypeId";
            public const string FirstNameAr = "FirstNameAr";
            public const string LastNameAr = "LastNameAr";
            public const string FirstNameEn = "FirstNameEn";
            public const string LastNameEn = "LastNameEn";
            public const string UserStatus = "UserStatus";
            public const string Email = "Email";
            public const string Nationality = "Nationality";
            public const string AspNetID = "AspNetID";

        }
        public class TemplatesType
        {
            public const string Quastionnaire = "Quastionnaire";
            public const string Toolkits = "Toolkits";
            public const string PolicyManagement = "PolicyManagement";
        }
        public class TemplateSubType
        {
            public const string ISO27 = "ISO27";
            public const string ISO24 = "ISO24";
            public const string ECC = "ECC";
            public const string SAMA = "SAMA";
        }
        public class Languages
        {
            public const string Arabic = "Ar";
            public const string English = "En";
        }
        //public struct UserType
        //{
        //    public const string Individual = "Individual";
        //    public const string Company = "Company";
        //    public const string CompanyMember = "CompanyMember";
        //    public const string Agent = "Agent";
        //    public const string AgentMember = "AgentMember";
        //}
        public class UserRoles
        {
            public const string RegisteredUser = "RegisteredUser";
            public const string Admin = "Admin";
            public const string Employee = "Employee";
            public const string AnonymousUser = "AnonymousUser";
        }

        public class ErrorsCodes
        {
            public const int UnhandledException = -101;
            public const int LookupDoesNotExist = -200;
            public const int NotificationDoesNotExist = -201;
            public const int SettingsGroupNameDoesNotExits = -202;
            public const int FailedToSendSMSNotification = -203;
            public const int FailedToSendEmailNotification = -204;
            public const int SettingNotFound = -205;
            public const int ServicesDoesNotExist = -206;
            public const int AddServicesFailed = -207;
            public const int SettingsDoesNotExist = -208;
            public const int GetUserWalletFailed = -209;
            public const int EWalletDoesNotExist = -210;
            public const int CompanyNotFound = -211;
            public const int UserNotFound = -212;
            public const int SuspendEWalletAccountFailed = -213;
            public const int ActiveEWalletAccountFailed = -214;
            public const int AddUserCreditFailed = -215;
            public const int AddCompanyCredit = -216;
            public const int BankWithdrawMoneyFailed = -217;
            public const int ManualWithdrawMoney = -218;
            public const int GetAllBulletins = -219;
            public const int RemoveServicesFailed = -220;
            public const int checkWalletAccessableClose = -221;
            public const int AcceptWithdrawMoney = -222;
            public const int CloseWallet = -223;
            public const int CannotDeleteAllServices = -224;
            public const int UploadWithdrawApplication = -225;
            public const int ApplicationImageNotFound = -226;
            public const int ActiveUsersSettingsListFailed = -227;
            public const int AddCreditSettings = -228;
            public const int GetUserTransActionFailed = -229;
            public const int ApplicationDoesNotExist = -230;
            public const int RejectWithdrawProccess = -231;
            public const int ActivatingEWalletFailed = -232;
            public const int DeductUserCredit = -233;
            public const int GetEWalletStatusFailed = -234;
            public const int CheckPaymentCodeFailed = -235;
            public const int CheckBalanceFailed = -236;
            public const int PayServiceFailed = -237;
            public const int CannotAddSystem = -238;
            public const int CannotUpdateSystem = -239;
            public const int CannotUpdateServices = -240;
            public const int CannotAddServices = -241;
            public const int CANNOTCreateBulletin = -242;
            public const int UpdateBulletin = -243;

            public const int CANNOTDeleteBulletin = -244;
        }
    }
}

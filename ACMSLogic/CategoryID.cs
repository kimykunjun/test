using System;

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for CategoryID.
	/// </summary>
	public class CategoryID
	{
		private CategoryID()
		{
		}
	}
	
	public enum CategoryType
	{
		PayOutstanding = 0,
		FitnessPackage = 1,
		FitnessGIRO = 99,
		PTPackage = 5,
		SpaSingleTreatment = 99,
		SpaPackage = 2,
		IPLPackage = 6,
		SpaCreditAccount = 7,
		FitnessCombinedPackage = 1,
		SpaCombinedPackage = 2, 
		UpgradePackage = 10,
		FitnessProduct = 3,
		SpaProduct = 4,
		CoursesNEvents = 14,
		LockerRental = 15,
		LockerDepositRefund = 16,
		ForgetCardRefund = 17,
		ReplaceMembershipCard = 20,
		MineralWater = 21,
		StaffPurchase = 22,
		Others = 23,
        HolisticFitness = 36,
        HolisticSpa = 37
	}
	//nCategoryID	strDescription
	//1	Fitness Package
	//2	Fitness GIRO
	//3	PT Package
	//4	Spa Single Treatment
	//5	Spa Package
	//6	IPL Package
	//7	Spa Credit Account
	//8	Fitness Combined Package
	//9	Spa Combined Package
	//10	Upgrade Package
	//11	Fitness Product
	//12	Spa Product
	//14	Courses & Events
	//15	Locker Rental
	//16	Locker Deposit(Refund)
	//17	Forget Card(Refund)
	//20	Replace Membership Card
	//21	Mineral Water
	//22	Staff Purchase
	//23	Others(i.e. Towel Rental)
	//0	Pay Outstanding
}

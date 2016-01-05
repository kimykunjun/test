using System;

namespace ACMSLogic
{
	/// <summary>
	/// Summary description for CardTypeID.
	/// </summary>
	public class CardTypeID
	{
		private CardTypeID()
		{
		}
	}

	public enum CardStatusType
	{
		RequestPrint = 0,
		PrintInProgress,
		Printed_AwaitingTransfer,
		InTransit,
		CardReceived,
		CardIssued,
		Cancelled,
		TransferRequest
	}
}

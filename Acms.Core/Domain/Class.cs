using System;
using System.Collections;

// generated using NHibernate.class.cst, see http://www.intesoft.net/nhibernate for notes and latest version

namespace Acms.Core.Domain
{
	#region Class
	
	/// <summary>
	/// Class object for NHibernate mapped table 'tblClass'.
	/// </summary>
	public class Class
	{
		#region Member Variables
		
		protected string _id;
		protected string _strDescription;
		protected ClassType _classType;
		protected IList _classSchedules = new ArrayList();
		protected IList _packageClasses = new ArrayList();
		protected IList _classInstances = new ArrayList();
		#endregion
		
		#region Constructors
		
		public Class() { }
		
		public Class( string strDescription, ClassType classType )
		{
			this._strDescription = strDescription;
			this._classType = classType;
		}
		
		#endregion		

		#region Public Properties
		
		public string Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public string StrDescription
		{
			get { return _strDescription; }
			set { _strDescription = value; }
		}
		
		public ClassType ClassType
		{
			get { return _classType; }
			set { _classType = value; }
		}

		public IList ClassSchedules
		{
			get { return _classSchedules; }
			set { _classSchedules = value; }
		}
		
		public IList PackageClasses
		{
			get { return _packageClasses; }
			set { _packageClasses = value; }
		}
		
		public IList ClassInstances
		{
			get { return _classInstances; }
			set { _classInstances = value; }
		}

		public void AddClassInstance(ClassInstance classInstance)
		{
			classInstance.Class = this;
			_classInstances.Add(classInstance);
			
		}

		public void AddPackageClass(PackageClass packageClass)
		{
			packageClass.Class = this;
			_packageClasses.Add(packageClass);
			
		}


		public void AddClassSchedule(ClassSchedule classSchedule)
		{
			classSchedule.Class = this;
			_classSchedules.Add(classSchedule);
			
		}
		
		#endregion
	}
	
	#endregion
}

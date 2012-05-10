﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Databases
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Proba")]
	public partial class ProbaDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTabl1(Tabl1 instance);
    partial void UpdateTabl1(Tabl1 instance);
    partial void DeleteTabl1(Tabl1 instance);
    partial void InsertTabl3(Tabl3 instance);
    partial void UpdateTabl3(Tabl3 instance);
    partial void DeleteTabl3(Tabl3 instance);
    #endregion
		
		public ProbaDataContext() : 
				base(global::Databases.Properties.Settings.Default.ProbaConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ProbaDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProbaDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProbaDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProbaDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Tabl2> Tabl2s
		{
			get
			{
				return this.GetTable<Tabl2>();
			}
		}
		
		public System.Data.Linq.Table<Tabl1> Tabl1s
		{
			get
			{
				return this.GetTable<Tabl1>();
			}
		}
		
		public System.Data.Linq.Table<Tabl3> Tabl3s
		{
			get
			{
				return this.GetTable<Tabl3>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Tabl2")]
	public partial class Tabl2
	{
		
		private int _n1;
		
		private string _s1;
		
		private string _s2;
		
		public Tabl2()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_n1", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int n1
		{
			get
			{
				return this._n1;
			}
			set
			{
				if ((this._n1 != value))
				{
					this._n1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_s1", DbType="VarChar(50)")]
		public string s1
		{
			get
			{
				return this._s1;
			}
			set
			{
				if ((this._s1 != value))
				{
					this._s1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_s2", DbType="VarChar(50)")]
		public string s2
		{
			get
			{
				return this._s2;
			}
			set
			{
				if ((this._s2 != value))
				{
					this._s2 = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Tabl1")]
	public partial class Tabl1 : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _s1;
		
		private string _s2;
		
		private int _n1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Ons1Changing(string value);
    partial void Ons1Changed();
    partial void Ons2Changing(string value);
    partial void Ons2Changed();
    partial void Onn1Changing(int value);
    partial void Onn1Changed();
    #endregion
		
		public Tabl1()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_s1", DbType="VarChar(50)")]
		public string s1
		{
			get
			{
				return this._s1;
			}
			set
			{
				if ((this._s1 != value))
				{
					this.Ons1Changing(value);
					this.SendPropertyChanging();
					this._s1 = value;
					this.SendPropertyChanged("s1");
					this.Ons1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_s2", DbType="VarChar(50)")]
		public string s2
		{
			get
			{
				return this._s2;
			}
			set
			{
				if ((this._s2 != value))
				{
					this.Ons2Changing(value);
					this.SendPropertyChanging();
					this._s2 = value;
					this.SendPropertyChanged("s2");
					this.Ons2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_n1", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int n1
		{
			get
			{
				return this._n1;
			}
			set
			{
				if ((this._n1 != value))
				{
					this.Onn1Changing(value);
					this.SendPropertyChanging();
					this._n1 = value;
					this.SendPropertyChanged("n1");
					this.Onn1Changed();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class Tabl3 : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _s1;
		
		private int _n1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Ons1Changing(string value);
    partial void Ons1Changed();
    partial void Onn1Changing(int value);
    partial void Onn1Changed();
    #endregion
		
		public Tabl3()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_s1", CanBeNull=false)]
		public string s1
		{
			get
			{
				return this._s1;
			}
			set
			{
				if ((this._s1 != value))
				{
					this.Ons1Changing(value);
					this.SendPropertyChanging();
					this._s1 = value;
					this.SendPropertyChanged("s1");
					this.Ons1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_n1", IsPrimaryKey=true)]
		public int n1
		{
			get
			{
				return this._n1;
			}
			set
			{
				if ((this._n1 != value))
				{
					this.Onn1Changing(value);
					this.SendPropertyChanging();
					this._n1 = value;
					this.SendPropertyChanged("n1");
					this.Onn1Changed();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
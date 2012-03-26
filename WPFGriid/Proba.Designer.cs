﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("ProbaModel", "FK_STab_FTab", "FTab", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(WPFGriid.FTab), "STab", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(WPFGriid.STab), true)]

#endregion

namespace WPFGriid
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class ProbaEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new ProbaEntities object using the connection string found in the 'ProbaEntities' section of the application configuration file.
        /// </summary>
        public ProbaEntities() : base("name=ProbaEntities", "ProbaEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ProbaEntities object.
        /// </summary>
        public ProbaEntities(string connectionString) : base(connectionString, "ProbaEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new ProbaEntities object.
        /// </summary>
        public ProbaEntities(EntityConnection connection) : base(connection, "ProbaEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<FTab> FTabs
        {
            get
            {
                if ((_FTabs == null))
                {
                    _FTabs = base.CreateObjectSet<FTab>("FTabs");
                }
                return _FTabs;
            }
        }
        private ObjectSet<FTab> _FTabs;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<STab> STabs
        {
            get
            {
                if ((_STabs == null))
                {
                    _STabs = base.CreateObjectSet<STab>("STabs");
                }
                return _STabs;
            }
        }
        private ObjectSet<STab> _STabs;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the FTabs EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToFTabs(FTab fTab)
        {
            base.AddObject("FTabs", fTab);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the STabs EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToSTabs(STab sTab)
        {
            base.AddObject("STabs", sTab);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ProbaModel", Name="FTab")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class FTab : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new FTab object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        public static FTab CreateFTab(global::System.Int32 id)
        {
            FTab fTab = new FTab();
            fTab.Id = id;
            return fTab;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String A
        {
            get
            {
                return _A;
            }
            set
            {
                OnAChanging(value);
                ReportPropertyChanging("A");
                _A = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("A");
                OnAChanged();
            }
        }
        private global::System.String _A;
        partial void OnAChanging(global::System.String value);
        partial void OnAChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String B
        {
            get
            {
                return _B;
            }
            set
            {
                OnBChanging(value);
                ReportPropertyChanging("B");
                _B = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("B");
                OnBChanged();
            }
        }
        private global::System.String _B;
        partial void OnBChanging(global::System.String value);
        partial void OnBChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ProbaModel", "FK_STab_FTab", "STab")]
        public EntityCollection<STab> STabs
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<STab>("ProbaModel.FK_STab_FTab", "STab");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<STab>("ProbaModel.FK_STab_FTab", "STab", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ProbaModel", Name="STab")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class STab : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new STab object.
        /// </summary>
        /// <param name="id1">Initial value of the Id1 property.</param>
        /// <param name="id">Initial value of the Id property.</param>
        public static STab CreateSTab(global::System.Int32 id1, global::System.Int32 id)
        {
            STab sTab = new STab();
            sTab.Id1 = id1;
            sTab.Id = id;
            return sTab;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String C
        {
            get
            {
                return _C;
            }
            set
            {
                OnCChanging(value);
                ReportPropertyChanging("C");
                _C = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("C");
                OnCChanged();
            }
        }
        private global::System.String _C;
        partial void OnCChanging(global::System.String value);
        partial void OnCChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String D
        {
            get
            {
                return _D;
            }
            set
            {
                OnDChanging(value);
                ReportPropertyChanging("D");
                _D = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("D");
                OnDChanged();
            }
        }
        private global::System.String _D;
        partial void OnDChanging(global::System.String value);
        partial void OnDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id1
        {
            get
            {
                return _Id1;
            }
            set
            {
                OnId1Changing(value);
                ReportPropertyChanging("Id1");
                _Id1 = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Id1");
                OnId1Changed();
            }
        }
        private global::System.Int32 _Id1;
        partial void OnId1Changing(global::System.Int32 value);
        partial void OnId1Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ProbaModel", "FK_STab_FTab", "FTab")]
        public FTab FTab
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<FTab>("ProbaModel.FK_STab_FTab", "FTab").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<FTab>("ProbaModel.FK_STab_FTab", "FTab").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<FTab> FTabReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<FTab>("ProbaModel.FK_STab_FTab", "FTab");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<FTab>("ProbaModel.FK_STab_FTab", "FTab", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}

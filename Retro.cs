	/// <summary>
	/// Класс взаимодействия с ПТК - провайдером
	/// </summary>
	class PTKRetroDataProvider: CustomRetroDataProvider
	{
		const string ADOCommandState = "Exec VT_OUT ?,?";
		const string ADOCommandTrend = "Exec VT_EXTREAD ?,?,?";
		public PTKRetroDataProvider(RetroQueryList qList, ReportTimeParams qTimes):base(qList, qTimes)
		{}
		public PTKRetroDataProvider(Stream stream): base(stream)
		{}
		protected override void DoExecute()
		{
			OleDbConnection conn = new OleDbConnection(ConfigurationSettings.AppSettings["RetroProviderConnectionString"]);
			OleDbCommand cmdState = new OleDbCommand(ADOCommandState, conn);
			OleDbCommand cmdTrend = new OleDbCommand(ADOCommandTrend, conn);
			OleDbParameter parStateDate = new OleDbParameter("StateDate", OleDbType.DBTimeStamp);
			OleDbParameter parBeginDate = new OleDbParameter("BeginDate", OleDbType.DBTimeStamp);
			OleDbParameter parEndDate = new OleDbParameter("EndDate", OleDbType.DBTimeStamp);
			OleDbParameter parSysnums1 = new OleDbParameter("Sysnums1", OleDbType.Variant);
			OleDbParameter parSysnums2 = new OleDbParameter("Sysnums2", OleDbType.Variant);
			cmdState.Parameters.Add(parStateDate);
			cmdTrend.Parameters.Add(parBeginDate);
			cmdTrend.Parameters.Add(parEndDate);
			cmdState.Parameters.Add(parSysnums1);
			cmdTrend.Parameters.Add(parSysnums2);
			//ввод значений параметров
			parBeginDate.Value = StartDate;
			parEndDate.Value   = EndDate;
			parStateDate.Value = StartDate;
			//заполнение списка системных номеров
			ArrayList prvSnList = cpxList.GetListForProvider();
			UInt16[,] arSysnums = new UInt16[prvSnList.Count,3];
			for (int i=0;i<prvSnList.Count;i++)
			{
				ProviderItem prvItem = (ProviderItem) prvSnList[i];
				arSysnums[i,0] = prvItem.Sysnum;
				arSysnums[i,1] = prvItem.Type;
				arSysnums[i,2] = prvItem.NumOut;
			}
			parSysnums1.Value   = arSysnums;
			parSysnums2.Value   = arSysnums;
			prvSnList = null;//больше не нужен

			//собственно запрос
			conn.Open();
			OleDbDataReader StateReader = cmdState.ExecuteReader();
			if (StateReader!=null)UnpackData(StateReader);
			StateReader.Close();
			OleDbDataReader TrendReader = cmdTrend.ExecuteReader();
			if (TrendReader!=null)UnpackData(TrendReader);
			TrendReader.Close();
			conn.Close();				
		}
	}

﻿/*
 * Created by SharpDevelop.
 * User: Mart
 * Date: 09.05.2012
 * Time: 16:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace PostSharpProba
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}
		
		void button1_Click(object sender, RoutedEventArgs e)
		{
			DateTime d = DateTime.Now;
			MessageBox.Show(d.ToString());
		}
	}
}
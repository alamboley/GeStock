﻿using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace GeStock
{
	public class GeStockItemDatabase
	{
		static object locker = new object ();
		SQLiteConnection database;
		/// <summary>
		/// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase.
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		public GeStockItemDatabase()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
			// create the tables
			database.CreateTable<GeStockItem>();
			database.CreateTable<Category>();
		}
		public IEnumerable<GeStockItem> GetItems ()
		{
			lock (locker) {
				return (from i in database.Table<GeStockItem>() select i).ToList();
			}
		}

		public IEnumerable<ControlKit> GetControlKits() {
			
			lock (locker) {
				return (from i in database.Table<ControlKit>() select i).ToList();
			}
		}

		public IEnumerable<GeStockItem> GetItemsNotDone ()
		{
			lock (locker) {
				return database.Query<GeStockItem>("SELECT * FROM [GeStockItem] WHERE [Done] = 0");
			}
		}
		public GeStockItem GetItem (int id)
		{
			lock (locker) {
				return database.Table<GeStockItem>().FirstOrDefault(x => x.ID == id);
			}
		}
		public int Save (IDBObject idbObject)
		{
			lock (locker) {
				if (idbObject.ID != 0) {
					database.Update(idbObject);
					return idbObject.ID;
				} else {
					return database.Insert(idbObject);
				}
			}
		}
		public int Delete<T>(T objectToDelete)
		{
			lock (locker) {
				return database.Delete<T> (((IDBObject)objectToDelete).ID);
			}
		}

		public GeStockItem FindItemNamed(string name) {

			lock (locker) {
				return database.Find<GeStockItem> (x => x.Name == name);
			}
		}

		public List<GeStockItem> FindItemsCloseToName(string name) {

			lock (locker) {

				return database.Query<GeStockItem> ("SELECT * FROM GeStockItem WHERE Name Like ?", '%' + name + '%');
			}
		}

		public Category GetCategory(int id) {

			lock (locker) {
				return database.Table<Category>().FirstOrDefault(x => x.ID == id);
			}
		}

		public IEnumerable<Category> GetCategories ()
		{
			lock (locker) {
				return (from i in database.Table<Category>() select i).ToList();
			}
		}
	}
}


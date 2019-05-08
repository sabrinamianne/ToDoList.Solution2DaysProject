using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using System.Collections.Generic;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class CategoryTest :IDisposable
  {
<<<<<<< HEAD
=======


    public CategoryTest()
   {
     DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=to_do_list_test;";
   }
    public void Dispose()
    {

      Category.ClearAll();
    }

    [TestMethod]
      public void CategoryConstructor_CreatesInstanceOfCategory_Category()
      {
        Category newCategory = new Category("test category");
        Assert.AreEqual(typeof(Category), newCategory.GetType());
      }
>>>>>>> 42c4e7d6fc6082d6511f3d4cdd71190cf0d9c09b

    public CategoryTests()
     {
       DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=to_do_list_test;";
     }


     //  [TestMethod]
  //  public void GetAll_CategoriesEmptyAtFirst_0()
  //  {
  //    //Arrange, Act
  //    int result = Category.GetAll().Count;
  //
  //    //Assert
  //    Assert.AreEqual(0, result);
  //  }
  //
  // [TestMethod]
  // public void Equals_ReturnsTrueIfNamesAreTheSame_Category()
  // {
  //   //Arrange, Act
  //   Category firstCategory = new Category("Household chores");
  //   Category secondCategory = new Category("Household chores");
  //
  //   //Assert
  //   Assert.AreEqual(firstCategory, secondCategory);
  // }

  // [TestMethod]
  // public void Save_SavesCategoryToDatabase_CategoryList()
  // {
  //   //Arrange
  //   Category testCategory = new Category("Household chores");
  //   testCategory.Save();
  //
  //   //Act
  //   List<Category> result = Category.GetAll();
  //   List<Category> testList = new List<Category>{testCategory};
  //
  //   //Assert
  //   CollectionAssert.AreEqual(testList, result);
  // }

//  [TestMethod]
//  public void Save_DatabaseAssignsIdToCategory_Id()
//  {
//    //Arrange
//    Category testCategory = new Category("Household chores");
//    testCategory.Save();
//
//    //Act
//    Category savedCategory = Category.GetAll()[0];
//
//    int result = savedCategory.GetId();
//    int testId = testCategory.GetId();
//
//    //Assert
//    Assert.AreEqual(testId, result);
// }

// [TestMethod]
// public void Find_FindsCategoryInDatabase_Category()
// {
//   //Arrange
//   Category testCategory = new Category("Household chores");
//   testCategory.Save();
//
//   //Act
//   Category foundCategory = Category.Find(testCategory.GetId());
//
//   //Assert
//   Assert.AreEqual(testCategory, foundCategory);
// }


[TestMethod]
    public void GetItems_RetrievesAllItemsWithCategory_ItemList()
    {
      //Arrange, Act
      Category testCategory = new Category("Household chores");
      testCategory.Save();
      Item firstItem = new Item("Mow the lawn", testCategory.GetId());
      firstItem.Save();
      Item secondItem = new Item("Do the dishes", testCategory.GetId());
      secondItem.Save();
      List<Item> testItemList = new List<Item> {firstItem, secondItem};
      List<Item> resultItemList = testCategory.GetItems();

      //Assert
      CollectionAssert.AreEqual(testItemList, resultItemList);
    }

     public void Dispose()
     {
       Item.DeleteAll();
       Category.DeleteAll();
     }


<<<<<<< HEAD
=======
          //Assert
          CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
          public void AddItem_AssociatesItemWithCategory_ItemList()
          {
            //Arrange
            string description = "Walk the dog.";
            Item newItem = new Item(description, 1);
            List<Item> newList = new List<Item> { newItem };
            string name = "Work";
            Category newCategory = new Category(name);
            newCategory.AddItem(newItem);

            //Act
            List<Item> result = newCategory.GetItems();

            //Assert
            CollectionAssert.AreEqual(newList, result);
          }


          [TestMethod]
             public void GetAll_CategoriesEmptyAtFirst_List()
             {
               //Arrange, Act
               int result = Category.GetAll().Count;

               //Assert
               Assert.AreEqual(0, result);
             }

>>>>>>> 42c4e7d6fc6082d6511f3d4cdd71190cf0d9c09b
  }
}

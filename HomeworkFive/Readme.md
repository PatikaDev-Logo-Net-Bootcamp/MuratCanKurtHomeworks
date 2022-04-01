# Homeworkfive
* BackgroundWorker oluşturulacak. https://jsonplaceholder.typicode.com/posts bu linketeki her bir dakikada çalışıp bu bilgileri çekip veri tabanına kayıt eden bir repository oluşturulacak.
* https://drive.google.com/file/d/17OUbFAua2kTngQLO7FGY-kxwvXLxnDEZ/view?usp=sharing bunun üstüne oluşturabilirsin. Post diye tablo oluşturulacak migration ile user, id, title, body postun kolonları olacak. 

# My Homework Steps
## Before Homework Request:
- Created a new API Solution
- Added Domain Layer, in domain layer, I have 1 BaseEntity with 1 Property which is Id, and 1 Entity inherited from BaseEntitiy, named Post.
- Added DataAccess.EntityFramework layer, It has Configuration, DbContext, Repository and Unit of work. I put them in the same layer, just to try and see how it looks...
  - **Warning**  
    VS won't recognize ```builder.ToTable("Posts")``` , You need to install ```Microsoft.EntityFrameworkCore.Relational``` package into Framework project using Nuget  to solve this.
  - In the repository I impemented filtering by using concept below. Just to experience the concept.
  ```C#
  public IQueryable<T> GetList(Expression<Func<T, bool>> filter = null);
  ```
  - Did not set a Primary key for id since it gets id from jsonplaceholder site.
- Added Business layer and PostService in it, Interface of service is in the same file.
  - Implemented methods, just for practicing the filtering concept mentioned above.
    ```C#
    List<Post> GetAllPosts();
    List<Post> GetUserPosts(int userId);
    Post GetById(int id);
    void AddPost(Post post);
    ````
- In the API project, added a PostsController with GetAll, GetByUser, GetById and AddPost actions.
- Configured the ```appsettings.json``` file to set up the database connection.
- Added DbContext, PostsService, Repository, UnitOfWork to Startup services.
  - **Warning**  
    VS won't recognize ```options.UseSqlServer``` in the,  
    ```C#
    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
    ```  
    You need to install ```Microsoft.EntityFrameworkCore.SqlServer``` package into main project using Nuget to solve this.
- Added Posts table to database using commands below in the Package Manager Console,  
```
Add-Migration AddPostsTable
Update-Database
```
- **Warning**  
  Before issuing these commands, you need to set your main project as startup project and select the EntityFramework layer as Package Manager Console default project, 
  ![image](https://user-images.githubusercontent.com/59605826/161305821-27522068-170d-40e2-ab30-908263e41b4a.png)
  **AND**
  - You need to install ```Microsoft.EntityFrameworkCore.Design``` to your **main project**,
  - You need to install ```Microsoft.EntityFrameworkCore.Tools``` to your **EntityFramework project** which is your migration project.
  - ![image](https://user-images.githubusercontent.com/59605826/161306068-b5fd2cd4-64d8-4a38-92e8-87be9467be5e.png)
- Controller Actions...
![image](https://user-images.githubusercontent.com/59605826/161351213-0c465c04-a5e2-4fa9-8827-643ec4800ad7.png)  

## My Homework
- I could put my background workers into a folder under my main project, but I decided to try to add as a Worker Service layer, so created a worker layer.
- There are two background workers in the layer,
- PostsFetchWorker, sends http requests to the site and adds the 'posts' in the request contend to the queue one by one.
- PostsRecordWorker, dequeues each post and uses AddPost overload method of PostService of the business layer to record them into database.

![image](https://user-images.githubusercontent.com/59605826/161350584-df902967-8e50-49ad-81aa-ae18e8d6a1aa.png)
![image](https://user-images.githubusercontent.com/59605826/161350654-89ad52e4-4118-434c-af94-4e6abfb967ff.png)
![image](https://user-images.githubusercontent.com/59605826/161351084-7a05950f-d973-4cde-bd3e-ad82726a1da5.png)
![image](https://user-images.githubusercontent.com/59605826/161351714-08e55771-7ee6-49ba-b923-feda83e16e81.png)




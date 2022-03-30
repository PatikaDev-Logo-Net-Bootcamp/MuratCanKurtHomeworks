## Homework four İstenenler:

* İlerlediğimiz projede yazdığımız CompanyService için sadece add ve get işlemi yapmıştık. Delete ve Update methodlarını implement edip apii de bunları kullanmalarını bekliyorum. Proje linkte ulaşabilirsiniz.
* https://drive.google.com/file/d/1Pc-3Fa_MjG3SLuO7YhwxJfFTbKO_IMrY/view?usp=drivesdk ,

* Ödeve artı 1 puan bonus

* Jwt token örneğindeki user ve password bilgilerini db çekecek şekilde UserService yazılması

## Homework four requests:
* We have coded only add and get operations for CompanyService in our lecture project, It is expected to add Delete and Update methods and use these in the api. We can use the lecture project to build on.
	- [Download Lecture Project](https://drive.google.com/file/d/1Pc-3Fa_MjG3SLuO7YhwxJfFTbKO_IMrY/view?usp=drivesdk)
### Bonus Request for 1 point
* Code the UserService to fecth user and password informations of Jwt example from db

# Homework notes

## Things I did before starting to do the Homework4 requests

### The whole project created from scratch with minor changes and refactorings
	- Necessary components of First.APP project included into ny main project ""Homework4" which is replacement of First.Api
	- Remaining of the First.APP is not created in my project.
	- Console project is not created.
	- All the packages have the version 5.0.15
	- WeatherForecast and its controller removed
	- Models:
		- CompanyResponse -> ResponseModel
		- TesterModel -> UserRegisterModel
		- UserModel -> UserLoginModel
	- Filters:
		- ValidationFilterAttribute in the First.APP is added to my project
	- Attributes/MaxFileSizeAttribute which was in the First.APP is add to my project
	- Other than these there are some minor naming changes.

## My Homework Four Report
- I added CompanyId property to CompanyDto since I need the Ids to delete or update the companies, we can't do it by using names or other properties since they may not be unique.
- Get all companies before trying update and delete.  
![image](https://user-images.githubusercontent.com/59605826/160919476-3f5c6d82-ad5f-4402-b8ab-968205b749f4.png)  
### Delete operation
- A Company object with just Id property set and created to pass into the repository method.
![image](https://user-images.githubusercontent.com/59605826/160920969-9058d4f9-8a4f-4f29-a238-f727bad1c7ed.png)
	- After deletion  
![image](https://user-images.githubusercontent.com/59605826/160921238-1bbd6e8d-f824-46da-9c1a-d41ae44e3d41.png)

### Update operation
- CompanyDTO is used for PUT operations
- I needed a GetById method in the repository and used in the update method of the company service to fecth the company to be updated and check the null properties of CompanyDTO that we don't want to change.
![image](https://user-images.githubusercontent.com/59605826/160933943-9eb81861-9b25-4a36-a980-2c86a51c74ea.png)
![image](https://user-images.githubusercontent.com/59605826/160934020-b4095bdb-a14f-4c7b-bc9e-bcec402ba143.png)

### Bonus
- Created A UserLogin Entity Under Domain, Added Users table and configs to EF, Added DI in StartUp file.
- Created UserLogins table by migration
- Changed Lifetime of JwtService to Scoped from singleton, because It wouldn't work with Transient Dbcontext and UserLoginServices.
![image](https://user-images.githubusercontent.com/59605826/160943331-0e361ef0-bbb7-4184-af37-2b833f39b62c.png)
![image](https://user-images.githubusercontent.com/59605826/160943458-857505c4-043e-4b09-8ed5-fc0ca3ff822d.png)
![image](https://user-images.githubusercontent.com/59605826/160943487-e8982d75-56cc-4702-a58b-ea8bcabe883f.png)
![image](https://user-images.githubusercontent.com/59605826/160943529-860eb74f-b069-41b1-85e1-982899cde61d.png)
![image](https://user-images.githubusercontent.com/59605826/160943559-9c78a5ff-ec8e-40bb-8a3f-a72e0477b663.png)


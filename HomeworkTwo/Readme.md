# HomeworkTwo
* Middleware yazılacak. İçeriği App version control (bu middleware option parametresi alacak parametre olarakta appsetting.json gelen app-version section değeri alacak)  
*  request login ve register ise bir sonraki pipeline'a geçsin (bu requestler dahil değildir altaki işlemler kontrol edilmeyecek)
*  request header da app-version key olacak, request header da gönderdiğim app-version değeri appsetting.json tuttuğum app-version  değerinden büyükse response 401 status kod olacak  
![image](https://user-images.githubusercontent.com/59605826/158082622-6e479777-97b1-40b9-8f22-8e5095e5ce4c.png)
![image](https://user-images.githubusercontent.com/59605826/158082647-5cb2accd-3074-4ca5-a0e5-4bd24ef024f5.png)  

![image](https://user-images.githubusercontent.com/59605826/158082705-b60149cf-8018-4d87-aaea-b7c8bf5995fd.png)
![image](https://user-images.githubusercontent.com/59605826/158082718-9c9c1b66-38f8-4211-b6c7-1ad30cdec770.png)

* Swagger headerına app-version default key eklenecek. (IOperationFilter interface kullanılarak)  
![image](https://user-images.githubusercontent.com/59605826/158082507-66f5e72e-c46b-42c0-b877-cfa28284f4d9.png)
![image](https://user-images.githubusercontent.com/59605826/158082548-a55ab300-9afc-4283-afda-410f0b81853d.png)
* Swagger 4 endpoint oluşturulacak istediğiniz gibi olabilir. Sadece bir tanesi gösterilmeyecek.  



* Middleware ve IOC hakkında 2 dakikalık okunacak, ingilizcesi iyi olanlar ingilizce yazacaklar, yetersiz olanlar ise türkçe makale yayımlayacaklar. Linkedin ve Medium yayınlanacak. Yayınlamadan önce telegram grubunda paylaşın ve birbirinize geri dönüş yapınız.

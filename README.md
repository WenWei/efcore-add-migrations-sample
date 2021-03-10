# 新增 Migrations 教學

* 新增 Class library(.NET Standard) 專案命名為 `Demo3.Migrations.Sqlserver`，設為 .NetStandard 2.1 版
* `Demo3.Migrations.Sqlserver` 加入Project reference `Demo3.Data`
* `Demo3` 加入 Project reference `Demo3.Migrations.Sqlserver`
* `Demo3` 加入 `Microsoft.EntityFrameworkCore.SqlServer` 套件
* `Demo3` 的 Startup.cs 設定連線字串，透過 `services.AddDbContext<EntertainmentContext>` 使用資料庫的 Provider。
* 在 Package Manager Console ，Default Project 設定為 `Demo3.Data`，建立 Migration 命令如下：
```
Add-Migration Description_for_migration_history -Project Demo3.Migrations.Sqlserver
```

執行命令後會在 Demo3.Migrations.Sqlserver 專案中建立 Migration 的程式碼


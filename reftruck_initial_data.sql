USE [ReftruckServiceCenterDB_v_22_26_10]
GO
BEGIN TRANSACTION T1;
GO
INSERT [dbo].[ExternalAutoRepairShops] ([Id], [Name], [Address], [Phone], [IsEnabled]) VALUES (N'1289a0dc-d01f-4635-a79d-0f7873a3be8c', N'توكيل منصور شيفورليه ', N'أكتوبر ', N'', 1)
GO
INSERT [dbo].[ExternalAutoRepairShops] ([Id], [Name], [Address], [Phone], [IsEnabled]) VALUES (N'93665963-3019-40da-b91c-3258b3ca4ceb', N'أولاد جاد ', N'عبده جاد العاشر من رمضان ', N'', 1)
GO
INSERT [dbo].[ExternalAutoRepairShops] ([Id], [Name], [Address], [Phone], [IsEnabled]) VALUES (N'5640d6ce-f183-4d0a-948d-744f08211281', N'التوكيل ', N'', N'', 1)
GO
INSERT [dbo].[ExternalAutoRepairShops] ([Id], [Name], [Address], [Phone], [IsEnabled]) VALUES (N'2cd40cad-e2a3-4299-bb56-9b22480f4095', N'جريش للزجاج ', N'', N'', 1)
GO
INSERT [dbo].[ExternalAutoRepairShops] ([Id], [Name], [Address], [Phone], [IsEnabled]) VALUES (N'f6e541ca-7f09-4a3f-900f-b3a285e7907f', N'بنزينه زيوت ', N'', N'', 1)
GO
INSERT [dbo].[ExternalAutoRepairShops] ([Id], [Name], [Address], [Phone], [IsEnabled]) VALUES (N'21fef362-d34c-4b85-90d7-f250792df913', N'السوق المحلي العاشر ', N'', N'', 1)
GO
INSERT [dbo].[Periods] ([Id], [Name], [FromDate], [ToDate], [State]) VALUES (N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'2022', CAST(N'2022-10-30 00:00:00.000' AS DateTime), CAST(N'2022-12-31 23:59:59.000' AS DateTime), N'Open')
GO
INSERT [dbo].[Periods] ([Id], [Name], [FromDate], [ToDate], [State]) VALUES (N'2cec9bcc-ebba-4811-9d35-4b46167ea77d', N'سولار 8', CAST(N'2022-08-01 00:00:00.000' AS DateTime), CAST(N'2022-08-30 23:59:59.000' AS DateTime), N'Open')
GO
INSERT [dbo].[Periods] ([Id], [Name], [FromDate], [ToDate], [State]) VALUES (N'7c089eed-ee09-433d-84fc-91401f1dd3e6', N'2021', CAST(N'2022-09-01 00:00:00.000' AS DateTime), CAST(N'2022-09-30 23:59:59.000' AS DateTime), N'Open')
GO
INSERT [dbo].[Periods] ([Id], [Name], [FromDate], [ToDate], [State]) VALUES (N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'10', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(N'2022-10-29 23:59:59.000' AS DateTime), N'Open')
GO
INSERT [dbo].[FuelTypes] ([Id], [Name], [Description]) VALUES (N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'Diesel', N'سولار')
GO
INSERT [dbo].[FuelTypes] ([Id], [Name], [Description]) VALUES (N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'Gasoline', N'بنزين')
GO
INSERT [dbo].[Locations] ([Id], [Name], [AddressLine], [IsEnabled]) VALUES (N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'المصنع', N'', 1)
GO
INSERT [dbo].[Locations] ([Id], [Name], [AddressLine], [IsEnabled]) VALUES (N'3af86c66-6b24-44ee-9469-c06bb47951b4', N'مركز الخدمة', N'', 1)
GO
INSERT [dbo].[Locations] ([Id], [Name], [AddressLine], [IsEnabled]) VALUES (N'fb01ba37-f018-46e1-b307-e1853c59063b', N'التوكيل', N'', 1)
GO
INSERT [dbo].[VehicelOvallStates] ([Id], [Name], [Description], [IsEnabled]) VALUES (N'c7ffc06e-e058-4470-bfe8-313516cb7fcf', N'حالة متهالكة', N'', 1)
GO
INSERT [dbo].[VehicelOvallStates] ([Id], [Name], [Description], [IsEnabled]) VALUES (N'b7d5be28-3409-42df-9f03-386cea51a960', N'حالة جيدة جدا', N'', 1)
GO
INSERT [dbo].[VehicelOvallStates] ([Id], [Name], [Description], [IsEnabled]) VALUES (N'afa715cd-4c14-4761-96c8-5ddc034195f9', N'حالة ممتازة', N'', 1)
GO
INSERT [dbo].[VehicelOvallStates] ([Id], [Name], [Description], [IsEnabled]) VALUES (N'39aa435e-e9f7-457a-9d24-8125c0085ca3', N'حالة متوسطة', N'', 1)
GO
INSERT [dbo].[VehicelOvallStates] ([Id], [Name], [Description], [IsEnabled]) VALUES (N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'حالة جيدة', N'', 1)
GO
INSERT [dbo].[VehicleCategories] ([Id], [Name], [Description], [IsFuelCardRequired], [IsChassisNumberRequired]) VALUES (N'2b8f04dc-c2fe-474c-9738-6897f6fa589b', N'Truck', N'السيارات النقل', 1, 1)
GO
INSERT [dbo].[VehicleCategories] ([Id], [Name], [Description], [IsFuelCardRequired], [IsChassisNumberRequired]) VALUES (N'c222cc0f-3016-4f1f-9299-6d27210555ca', N'Microbus', N'ميكروباص', 1, 1)
GO
INSERT [dbo].[VehicleCategories] ([Id], [Name], [Description], [IsFuelCardRequired], [IsChassisNumberRequired]) VALUES (N'4129a943-32e9-4eeb-9bda-7f454624d989', N'Bus', N'الاتوبيسات', 1, 1)
GO
INSERT [dbo].[VehicleCategories] ([Id], [Name], [Description], [IsFuelCardRequired], [IsChassisNumberRequired]) VALUES (N'027db85f-5dd6-4692-a7f3-d68bf2d5f51c', N'Forklift', N'الكلاركات', 0, 0)
GO
INSERT [dbo].[VehicleCategories] ([Id], [Name], [Description], [IsFuelCardRequired], [IsChassisNumberRequired]) VALUES (N'68926638-6738-4dd3-a09b-ebe6672629c0', N'Passanger', N'السيارات الملاكى', 1, 1)
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'6d599044-44dc-4800-8dc1-069c34a06b41', N'هيونداي فيرنا 2015', N'م/ملاك محسن ', N'9bfb506e-73b1-409c-a925-dbf9f841e559')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'f135c106-e9c8-4566-826e-0d4166ac779c', N'هيونداى فيرنا - مانوال', N'', N'9bfb506e-73b1-409c-a925-dbf9f841e559')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'722e94bd-2790-4923-b221-1990c37403ac', N'أوتوبيس - شيفروليه - MCV', N'', N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'c4c813ac-b881-43e4-9d6d-1cd96656fb4c', N'هيونداي ماتريكس ', N'أ.وجدي ', N'9bfb506e-73b1-409c-a925-dbf9f841e559')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'a3d952f5-3f4e-431d-b84b-20467edb3152', N'شيفرليه أفيو', N'', N'9bfb506e-73b1-409c-a925-dbf9f841e559')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'64f59cb3-1d4d-400c-a918-23ffa76af5fb', N'اسكودا أوكتافيا', N'', N'9bfb506e-73b1-409c-a925-dbf9f841e559')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'bc7d6afc-c491-43f4-b5b3-24380d609c91', N'ميكروباص تويوتا', N'', N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'08e9dd71-d4c7-442b-a1a3-26b20ab79da0', N'سبورتاج ', N'أ.ثروت ', N'9bfb506e-73b1-409c-a925-dbf9f841e559')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'1fda0aaa-a3d7-4316-a443-3ef0b330dce5', N'تويوتا فان', N'', N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'3139046a-6bd2-4c43-a5e3-47227b656b55', N'هيونداى فيرنا - أوتوماتيك', N'', N'9bfb506e-73b1-409c-a925-dbf9f841e559')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'b5a6ab7c-97a0-4696-84db-572e4de416aa', N'أوبل أستر', N'', N'9bfb506e-73b1-409c-a925-dbf9f841e559')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'92536e6c-bf46-4bf7-a609-5b3786897bc5', N'شيفرليه  - جامبو 5000', N'', N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'bd6fb5c3-0a54-4fb6-b096-5c851e838609', N'نيسان دبل كابينة', N'', N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'08b5654e-1c51-4e3a-a473-602d3e814aa2', N'ديماكس دبل كابينة', N'', N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'c2164621-32bc-45bd-92d8-66faad30b835', N' v هيونداي ', N'أ.داوود', N'9bfb506e-73b1-409c-a925-dbf9f841e559')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'5a55b7bb-a8f7-4c8e-903d-678adcb22bae', N'هيونداى توسان', N'', N'9bfb506e-73b1-409c-a925-dbf9f841e559')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'c752763d-39fc-4f5d-bfd7-77be7261d7ce', N'كوماتسو', N'', N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'24866783-80fa-4ed9-8ed0-8880ce9b19a4', N'MG', N'', N'9bfb506e-73b1-409c-a925-dbf9f841e559')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'bc3668cd-3289-4511-b847-8e370c0a9110', N'مرسيدس فان', N'', N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'c9b0b713-30e3-48d0-b01c-aaaaf5bf980a', N'ميكروباص فوتون', N'', N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'7df83363-4702-4ee1-be32-ac01f8a5ea76', N'متسوبيشى كانتر', N'', N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'303fbc8f-d59b-4367-b82f-b1682c3a12e2', N'FIAT Microbus', N'الصيانه الخارجيه ', N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'a6aed18b-d27b-4cf5-a39f-c271e28c8059', N'مرسيدس شبل', N'', N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'ef9c5d09-cd53-486f-9155-d24c389e6ab7', N'TCM', N'', N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'ff6f675c-d7bc-4377-95f0-dedcc3c58f8a', N'شيفرليه ديماكس', N'', N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'3b93c3c3-5d9d-400b-8ff5-e4ba02736eac', N'Toyota', N'', N'9bfb506e-73b1-409c-a925-dbf9f841e559')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'a83985e9-76d6-4097-95d4-e5dcbadc2e3b', N'ميتسوبيشي ملاكي ', N'أ/فيكتور ', N'9bfb506e-73b1-409c-a925-dbf9f841e559')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'51a37a72-4e82-43d0-81fa-e914b51bb220', N'fiat', N'مؤمن السباعي ', N'9bfb506e-73b1-409c-a925-dbf9f841e559')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'c33ca718-2cb8-4fab-a99f-ede4cb2f27e3', N'أوتوبيس - شيفروليه - خلف', N'', N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'2991f77e-6319-498e-9ab6-f1aaa2ca39ca', N'نيسان صني  - N17 - أوتوماتيك', N'', N'9bfb506e-73b1-409c-a925-dbf9f841e559')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'2d84f8b4-e96b-4b8c-892f-f627ed7770ee', N'مرسيدس قلاب  ', NULL, N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'c9afe4ca-5fc5-4ff9-bac4-fa62a65ed8ca', N'شيفرليه  - جامبو 8000', N'', N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[VehicleModels] ([Id], [Name], [Description], [DefaultFuelTypeId]) VALUES (N'1b556ce4-86d5-43b6-b17a-fe25ed8e6755', N'كاتربلر', N'', N'ab57c5ec-6b01-4790-964e-ce393c747e0a')
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'59cc5194-87f8-4b61-8481-0024098a7a51', N'44060', N'', N'1859', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'a3d952f5-3f4e-431d-b84b-20467edb3152', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2014)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'e744bfcc-6c54-45c8-ac36-02de9525f676', N'56517', N'', N'4956', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'b5a6ab7c-97a0-4696-84db-572e4de416aa', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2021)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'e1640fa4-cc37-4ce5-8b03-04d7e59cb71c', N'644234', N'', N'3782 ر ب ع ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'2b8f04dc-c2fe-474c-9738-6897f6fa589b', N'c9afe4ca-5fc5-4ff9-bac4-fa62a65ed8ca', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2016)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'aaf26a2d-8246-45e9-ae5c-089c6dda296f', N'79401', N'', N'8437 ر ن  ب', N'39aa435e-e9f7-457a-9d24-8125c0085ca3', N'c222cc0f-3016-4f1f-9299-6d27210555ca', N'bc3668cd-3289-4511-b847-8e370c0a9110', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 1999)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'2bbab590-5ad1-48b8-a2e8-0b69100c9bf8', N'2001053', N'', N'مرسيدس شبل ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'2b8f04dc-c2fe-474c-9738-6897f6fa589b', N'a6aed18b-d27b-4cf5-a39f-c271e28c8059', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2000)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'7a24062f-038f-4f9f-8f7b-10c747a40968', N'239452', N'', N'5892', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'f135c106-e9c8-4566-826e-0d4166ac779c', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'3af86c66-6b24-44ee-9469-c06bb47951b4', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2017)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'629fceac-bee0-4b54-91b6-19b29664c629', N'7112121', N'', N'4152 ر ف ب ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'2b8f04dc-c2fe-474c-9738-6897f6fa589b', N'ff6f675c-d7bc-4377-95f0-dedcc3c58f8a', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2009)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'e0ffa888-eca9-4ddd-81a0-20517f293f32', N'7100169', N'', N'9736', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'4129a943-32e9-4eeb-9bda-7f454624d989', N'722e94bd-2790-4923-b221-1990c37403ac', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2011)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'f9233b79-c126-4872-9628-2d866b7a200e', N'15266', N'', N'5896', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'3139046a-6bd2-4c43-a5e3-47227b656b55', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'3af86c66-6b24-44ee-9469-c06bb47951b4', N'3af86c66-6b24-44ee-9469-c06bb47951b4', NULL, 2017)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'8ac5ed1b-db83-4b55-8c0f-347971004e15', N'22', N'', N'كلارك 2 طن ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'027db85f-5dd6-4692-a7f3-d68bf2d5f51c', N'1b556ce4-86d5-43b6-b17a-fe25ed8e6755', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2022)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'3cb7d791-3884-4dc2-87bb-3832c0c76b9f', N'191777', N'', N'8924', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'f135c106-e9c8-4566-826e-0d4166ac779c', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'3af86c66-6b24-44ee-9469-c06bb47951b4', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2014)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'db9cb7a2-9fda-46fe-b82a-3b57fbb2054e', N'109073', N'', N'6389', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'2991f77e-6319-498e-9ab6-f1aaa2ca39ca', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'3af86c66-6b24-44ee-9469-c06bb47951b4', N'fb01ba37-f018-46e1-b307-e1853c59063b', NULL, 2021)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'7d969004-d881-4e65-83e3-3c02a7667fe2', N'KP253772', N'', N'8342', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'5a55b7bb-a8f7-4c8e-903d-678adcb22bae', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'fb01ba37-f018-46e1-b307-e1853c59063b', NULL, 2019)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'aa089b5a-30e7-4f3d-a73c-3d878066fb8b', N'38365', N'', N'4781', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'24866783-80fa-4ed9-8ed0-8880ce9b19a4', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'3af86c66-6b24-44ee-9469-c06bb47951b4', N'fb01ba37-f018-46e1-b307-e1853c59063b', NULL, 2021)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'ff9e1912-94be-4f26-9d5f-475373234a44', N'253133', N'', N'9137', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'f135c106-e9c8-4566-826e-0d4166ac779c', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'3af86c66-6b24-44ee-9469-c06bb47951b4', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2019)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'f3338864-6ced-40ab-9f20-490704f49998', N'12918', N'', N'9759 ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'3139046a-6bd2-4c43-a5e3-47227b656b55', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2015)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'84afc3f2-f5a1-4c74-a917-4cc3dee71c92', N'7100200', N'', N'1295', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'4129a943-32e9-4eeb-9bda-7f454624d989', N'722e94bd-2790-4923-b221-1990c37403ac', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2012)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'0f1c705d-169d-410e-b222-4da960b7bc98', N'138263', N'', N'3217 ر أ ق', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'c222cc0f-3016-4f1f-9299-6d27210555ca', N'bc7d6afc-c491-43f4-b5b3-24380d609c91', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2014)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'1a63578a-abcf-4c9c-be37-4df4cd41cb61', N'0000', N'', N'9572 ر ه ل ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'2b8f04dc-c2fe-474c-9738-6897f6fa589b', N'7df83363-4702-4ee1-be32-ac01f8a5ea76', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2015)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'44b6d5ca-9440-4d42-83bc-50c65c2de726', N'260476', N'', N'2736', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'4129a943-32e9-4eeb-9bda-7f454624d989', N'722e94bd-2790-4923-b221-1990c37403ac', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2015)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'85872c47-43a5-4332-8419-511737ed049a', N'123', N'1827', N'1827', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'2b8f04dc-c2fe-474c-9738-6897f6fa589b', N'a6aed18b-d27b-4cf5-a39f-c271e28c8059', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2000)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'9a1696b9-a03e-468d-9f56-51d62124e39b', N'260475', N'', N'2735', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'4129a943-32e9-4eeb-9bda-7f454624d989', N'722e94bd-2790-4923-b221-1990c37403ac', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2015)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'9835f2f0-96ea-4154-a429-599ac437befc', N'56823', N'', N'4953', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'b5a6ab7c-97a0-4696-84db-572e4de416aa', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'fb01ba37-f018-46e1-b307-e1853c59063b', NULL, 2021)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'febec3b4-729e-4b51-99d1-5abc7abbf8ff', N'19744', N'', N'1474', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'24866783-80fa-4ed9-8ed0-8880ce9b19a4', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'3af86c66-6b24-44ee-9469-c06bb47951b4', N'fb01ba37-f018-46e1-b307-e1853c59063b', NULL, 2022)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'b8628b39-d8a4-47f8-90c0-5e2be313e9ad', N'4152455', N'7391 L F R ', N'7391', NULL, N'c222cc0f-3016-4f1f-9299-6d27210555ca', N'24866783-80fa-4ed9-8ed0-8880ce9b19a4', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', NULL, N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2021)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'4eb7c504-1c12-4a84-aede-65608c8e5613', N'E00558', N'', N'2685 ر ف ل ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'2b8f04dc-c2fe-474c-9738-6897f6fa589b', N'bd6fb5c3-0a54-4fb6-b096-5c851e838609', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2014)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'ce60c3fd-17da-4655-9632-65d56796e274', N'23095', N'', N'3495 ر ف ل ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'2b8f04dc-c2fe-474c-9738-6897f6fa589b', N'ff6f675c-d7bc-4377-95f0-dedcc3c58f8a', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2014)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'5527903c-95d6-4888-a380-67f3bc3a0874', N'2', N'', N'كلارك 3 طن ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'027db85f-5dd6-4692-a7f3-d68bf2d5f51c', N'1b556ce4-86d5-43b6-b17a-fe25ed8e6755', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2022)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'31652916-d092-460c-aae1-697c84572e0b', N'154215', N'', N'9417', N'39aa435e-e9f7-457a-9d24-8125c0085ca3', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'f135c106-e9c8-4566-826e-0d4166ac779c', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2012)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'cdf2dbdf-ae1c-40e8-b529-6c6b26bd378f', N'123', N'', N'كلارك الصناديق ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'027db85f-5dd6-4692-a7f3-d68bf2d5f51c', N'1b556ce4-86d5-43b6-b17a-fe25ed8e6755', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2022)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'0c14c073-eb74-41de-9946-6cf959f06500', N'71001700', N'', N'9735', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'4129a943-32e9-4eeb-9bda-7f454624d989', N'722e94bd-2790-4923-b221-1990c37403ac', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2011)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'e3357092-4472-430b-8e52-715e794112df', N'145245', N'6498 D A R ', N'6498', NULL, N'4129a943-32e9-4eeb-9bda-7f454624d989', N'3139046a-6bd2-4c43-a5e3-47227b656b55', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', NULL, NULL, NULL, 2022)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'da13276e-08ad-430b-a16e-7c00b9c3a6ee', N'232687', N'', N'2431', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'4129a943-32e9-4eeb-9bda-7f454624d989', N'722e94bd-2790-4923-b221-1990c37403ac', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2015)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'e5055e77-1581-43b4-8948-808d17c03cdc', N'145522', N'897 T H E ', N'897', NULL, N'4129a943-32e9-4eeb-9bda-7f454624d989', N'24866783-80fa-4ed9-8ed0-8880ce9b19a4', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', NULL, NULL, NULL, 2022)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'62d3bfb0-177c-4428-886f-8335e3d5c968', N'12452', N'259 GRR', N'259', N'b7d5be28-3409-42df-9f03-386cea51a960', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'f135c106-e9c8-4566-826e-0d4166ac779c', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'3af86c66-6b24-44ee-9469-c06bb47951b4', NULL, 2015)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'cac6172d-db8b-402d-b6f1-8b0e631f1b70', N'24578', N'759 K F B ', N'759', NULL, N'68926638-6738-4dd3-a09b-ebe6672629c0', N'7df83363-4702-4ee1-be32-ac01f8a5ea76', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', NULL, NULL, NULL, 2016)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'55d22131-b139-4290-a79a-8e11bf36d261', N'0000', N'', N'كلارك النظافه', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'027db85f-5dd6-4692-a7f3-d68bf2d5f51c', N'1b556ce4-86d5-43b6-b17a-fe25ed8e6755', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2022)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'2f5ddb67-5647-44cf-b093-8fd2432695b6', N'7100318', N'', N'1832', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'4129a943-32e9-4eeb-9bda-7f454624d989', N'722e94bd-2790-4923-b221-1990c37403ac', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2013)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'6acc7c2f-29fe-49ea-88d9-92940f04836a', N'804409', N'', N'3165', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'4129a943-32e9-4eeb-9bda-7f454624d989', N'722e94bd-2790-4923-b221-1990c37403ac', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2017)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'27c951ef-d080-4e9c-8840-9d04e5a7706b', N'21538', N'', N'3852', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'24866783-80fa-4ed9-8ed0-8880ce9b19a4', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'3af86c66-6b24-44ee-9469-c06bb47951b4', N'fb01ba37-f018-46e1-b307-e1853c59063b', NULL, 2021)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'02d27c34-c4df-4f70-b618-9d20a7122d6e', N'7100562', N'', N'1392', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'2b8f04dc-c2fe-474c-9738-6897f6fa589b', N'c9afe4ca-5fc5-4ff9-bac4-fa62a65ed8ca', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2014)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'd8730201-0d2d-41e1-a25e-a20f2bdcbca9', N'249031', N'', N'2235', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'f135c106-e9c8-4566-826e-0d4166ac779c', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'3af86c66-6b24-44ee-9469-c06bb47951b4', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2018)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'87a0a98b-2b93-42fa-b216-a7e222a3c47e', N'451421', N'', N'168', NULL, N'4129a943-32e9-4eeb-9bda-7f454624d989', N'b5a6ab7c-97a0-4696-84db-572e4de416aa', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', NULL, NULL, NULL, 2022)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'b53879f0-f30a-4142-83f0-ab9d204c5234', N'CE3119', N'', N'2967 ر ب ع ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'2b8f04dc-c2fe-474c-9738-6897f6fa589b', N'bd6fb5c3-0a54-4fb6-b096-5c851e838609', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2016)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'733d6d7f-a0a8-45fc-9334-abfe9ed38d99', N'CEF44615', N'', N'قلاب كانتر ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'2b8f04dc-c2fe-474c-9738-6897f6fa589b', N'7df83363-4702-4ee1-be32-ac01f8a5ea76', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2022)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'c34788b5-3e3a-47be-b700-ac136d1c7d51', N'771589', N'', N'2764', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'4129a943-32e9-4eeb-9bda-7f454624d989', N'722e94bd-2790-4923-b221-1990c37403ac', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2016)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'403170b2-191b-4034-afd0-acab034f54fd', N'1', N'', N'5طن خط الصاج ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'027db85f-5dd6-4692-a7f3-d68bf2d5f51c', N'1b556ce4-86d5-43b6-b17a-fe25ed8e6755', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2022)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'095c58e0-d4bc-4060-96ec-b2f273bde261', N'177232', N'', N'3169', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'f135c106-e9c8-4566-826e-0d4166ac779c', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'3af86c66-6b24-44ee-9469-c06bb47951b4', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2013)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'30743d58-8ba4-438b-a318-b4f60b850146', N'39115', N'', N'2733', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'64f59cb3-1d4d-400c-a918-23ffa76af5fb', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'fb01ba37-f018-46e1-b307-e1853c59063b', NULL, 2016)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'4adc829e-3067-4226-b9e1-ba21cdc51caf', N'71199', N'', N'1739 ر ل ص ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'c222cc0f-3016-4f1f-9299-6d27210555ca', N'c9b0b713-30e3-48d0-b01c-aaaaf5bf980a', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2019)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'd1eec598-6777-4228-83f0-be5005d36115', N'239302', N'', N'6839', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'5a55b7bb-a8f7-4c8e-903d-678adcb22bae', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2017)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'f90e9589-1814-4c59-b658-c1fe703647f3', N'ME030088', N'', N'3249', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'4129a943-32e9-4eeb-9bda-7f454624d989', N'722e94bd-2790-4923-b221-1990c37403ac', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'3af86c66-6b24-44ee-9469-c06bb47951b4', N'fb01ba37-f018-46e1-b307-e1853c59063b', NULL, 2021)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'b535df05-37aa-47cc-8866-c36a61110dff', N'975015415', N'', N'9678 ر ن ب', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'c222cc0f-3016-4f1f-9299-6d27210555ca', N'bc7d6afc-c491-43f4-b5b3-24380d609c91', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'3af86c66-6b24-44ee-9469-c06bb47951b4', N'3af86c66-6b24-44ee-9469-c06bb47951b4', NULL, 2012)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'3f7d67d4-1f3f-4f58-8e4b-c88279312e6f', N'71001033', N'', N'1485', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'4129a943-32e9-4eeb-9bda-7f454624d989', N'722e94bd-2790-4923-b221-1990c37403ac', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2012)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'6a3a5d68-0baf-4d66-8a88-c9cc5e856824', N'21111111', N'215 E L H ', N'215', NULL, N'4129a943-32e9-4eeb-9bda-7f454624d989', N'5a55b7bb-a8f7-4c8e-903d-678adcb22bae', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', NULL, NULL, NULL, 2022)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'30e5bf29-a82e-43ef-a278-ce7f9a17a5bb', N'11111', N'', N'كلارك المخزن ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'027db85f-5dd6-4692-a7f3-d68bf2d5f51c', N'1b556ce4-86d5-43b6-b17a-fe25ed8e6755', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2022)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'2982dfb2-011d-4490-9e7e-d2c52e4aa6a7', N'2785', N'', N'2469', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'2991f77e-6319-498e-9ab6-f1aaa2ca39ca', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2013)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'1f26048d-945e-4847-ba69-d4ce3c30491d', N'232685', N'', N'2435', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'4129a943-32e9-4eeb-9bda-7f454624d989', N'722e94bd-2790-4923-b221-1990c37403ac', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2015)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'07ea6a54-0124-4acd-8d2e-d8da054eb143', N'ME030042', N'', N'3248', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'4129a943-32e9-4eeb-9bda-7f454624d989', N'722e94bd-2790-4923-b221-1990c37403ac', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'fb01ba37-f018-46e1-b307-e1853c59063b', NULL, 2021)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'00cb1d65-7936-4ec9-97cd-da9f1cdd5023', N'7102315', N'', N'8716', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'4129a943-32e9-4eeb-9bda-7f454624d989', N'c33ca718-2cb8-4fab-a99f-ede4cb2f27e3', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2010)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'5adea443-8285-4566-8b8a-e0547e1f6cd8', N'16321', N'', N'2688', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'3139046a-6bd2-4c43-a5e3-47227b656b55', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'3af86c66-6b24-44ee-9469-c06bb47951b4', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2018)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'725cfca3-e869-412b-9c34-e3a2a04404b3', N'233801', N'', N'3751 ر ه ب ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'2b8f04dc-c2fe-474c-9738-6897f6fa589b', N'92536e6c-bf46-4bf7-a609-5b3786897bc5', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2015)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'602613a4-1aa1-46fb-9524-e50661c296fd', N'000', N'', N'127', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'f135c106-e9c8-4566-826e-0d4166ac779c', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2015)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'fd37a907-c983-4382-ba4d-e91921b1063f', N'5212', N'', N'كلارك التجميع ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'027db85f-5dd6-4692-a7f3-d68bf2d5f51c', N'1b556ce4-86d5-43b6-b17a-fe25ed8e6755', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2022)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'7ffddc67-948a-4879-85b4-ecc8c5c172af', N'R009335', N'', N'1683', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'3b93c3c3-5d9d-400b-8ff5-e4ba02736eac', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'fb01ba37-f018-46e1-b307-e1853c59063b', NULL, 2019)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'f45302b0-0c64-4160-9de7-f8f8e4a3ab04', N'7117155', N'', N'2364 ر و ب ', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'2b8f04dc-c2fe-474c-9738-6897f6fa589b', N'08b5654e-1c51-4e3a-a473-602d3e814aa2', N'Working', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', NULL, 2012)
GO
INSERT [dbo].[Vehicles] ([Id], [ChassisNumber], [VehicleCode], [InternalCode], [OverallStateId], [VehicleCategoryId], [VehicelModelId], [WorkingState], [FuelTypeId], [WorkLocationId], [MaintenanceLocationId], [DriverId], [ModelYear]) VALUES (N'bf49ab71-427a-4339-a6e0-fd2b01ccb641', N'29973', N'', N'7648', N'13c7ed2b-2b56-47ae-a164-ecb1a07e02c2', N'68926638-6738-4dd3-a09b-ebe6672629c0', N'24866783-80fa-4ed9-8ed0-8880ce9b19a4', N'Working', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'b44ef8cb-e606-4178-a4dd-2d4d102c1a02', N'fb01ba37-f018-46e1-b307-e1853c59063b', NULL, 2021)
GO
SET IDENTITY_INSERT [dbo].[ExternalRepairBills] ON 

GO
INSERT [dbo].[ExternalRepairBills] ([Id], [Number], [SupplierBillNumber], [VehicleId], [ExternalAutoRepairShopId], [BillDate], [Repairs], [TotalAmountInEGP], [PeriodId], [BillImageFilePath], [Vehicle_Id], [ExternalAutoRepairShop_Id]) VALUES (N'3b308d4d-117c-43be-ba84-e1dc3127a76d', 6, N'1', N'31652916-d092-460c-aae1-697c84572e0b', N'93665963-3019-40da-b91c-3258b3ca4ceb', CAST(N'2022-11-02 10:32:50.557' AS DateTime), N'     تم أصلاح حادث أمامي يمين و البنود كالأتي  1-فانوس أمامي750 ج  يمين                زجاج   950 ج أمامي  3 -أكصدام 650 ج أمامي    4-جوان داير 450 ج زجاج      5-لمبه 65 ج                        /   KM 250612  / خامات دهان كابوت و رفرف و اكصام 500 ج  ', CAST(3000.00 AS Decimal(18, 2)), N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'D:\Malak\Cost\9417 فيرنا المصنع\nov\WhatsApp Image 2022-11-02 at 10.43.45 AM.jpeg', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[ExternalRepairBills] OFF
GO
SET IDENTITY_INSERT [dbo].[SparePartsPriceLists] ON 

GO
INSERT [dbo].[SparePartsPriceLists] ([Id], [Number], [Name]) VALUES (N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', 2, N'P')
GO
SET IDENTITY_INSERT [dbo].[SparePartsPriceLists] OFF
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'59cc5194-87f8-4b61-8481-0024098a7a51', N'88443', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'e744bfcc-6c54-45c8-ac36-02de9525f676', N'13101', N'بنزين', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'e1640fa4-cc37-4ce5-8b03-04d7e59cb71c', N'88422', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'aaf26a2d-8246-45e9-ae5c-089c6dda296f', N'88411', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'2bbab590-5ad1-48b8-a2e8-0b69100c9bf8', N'88456', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'7a24062f-038f-4f9f-8f7b-10c747a40968', N'140943', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'629fceac-bee0-4b54-91b6-19b29664c629', N'88413', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'e0ffa888-eca9-4ddd-81a0-20517f293f32', N'88435', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'f9233b79-c126-4872-9628-2d866b7a200e', N'141027', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'3cb7d791-3884-4dc2-87bb-3832c0c76b9f', N'138899', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'db9cb7a2-9fda-46fe-b82a-3b57fbb2054e', N'133710', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'7d969004-d881-4e65-83e3-3c02a7667fe2', N'88450', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'aa089b5a-30e7-4f3d-a73c-3d878066fb8b', N'145564', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'ff9e1912-94be-4f26-9d5f-475373234a44', N'88441', N'بنزين', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'f3338864-6ced-40ab-9f20-490704f49998', N'149570', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'84afc3f2-f5a1-4c74-a917-4cc3dee71c92', N'139562', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'0f1c705d-169d-410e-b222-4da960b7bc98', N'138909', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'1a63578a-abcf-4c9c-be37-4df4cd41cb61', N'138905', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'44b6d5ca-9440-4d42-83bc-50c65c2de726', N'138900', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'85872c47-43a5-4332-8419-511737ed049a', N'152231', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'9a1696b9-a03e-468d-9f56-51d62124e39b', N'138904', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'9835f2f0-96ea-4154-a429-599ac437befc', N'133100', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'febec3b4-729e-4b51-99d1-5abc7abbf8ff', N'157990', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'b8628b39-d8a4-47f8-90c0-5e2be313e9ad', N'152228', N'بنزين', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'4eb7c504-1c12-4a84-aede-65608c8e5613', N'138903', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'ce60c3fd-17da-4655-9632-65d56796e274', N'138901', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'31652916-d092-460c-aae1-697c84572e0b', N'88451', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'0c14c073-eb74-41de-9946-6cf959f06500', N'88434', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'e3357092-4472-430b-8e52-715e794112df', N'150985', N'بنزين', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'da13276e-08ad-430b-a16e-7c00b9c3a6ee', N'138908', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'e5055e77-1581-43b4-8948-808d17c03cdc', N'197245', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'62d3bfb0-177c-4428-886f-8335e3d5c968', N'208351', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'cac6172d-db8b-402d-b6f1-8b0e631f1b70', N'144652', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'2f5ddb67-5647-44cf-b093-8fd2432695b6', N'88432', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'6acc7c2f-29fe-49ea-88d9-92940f04836a', N'138907', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'27c951ef-d080-4e9c-8840-9d04e5a7706b', N'134257', N'بنزين', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'02d27c34-c4df-4f70-b618-9d20a7122d6e', N'138902', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'd8730201-0d2d-41e1-a25e-a20f2bdcbca9', N'88437', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'87a0a98b-2b93-42fa-b216-a7e222a3c47e', N'88447', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'b53879f0-f30a-4142-83f0-ab9d204c5234', N'206154', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'733d6d7f-a0a8-45fc-9334-abfe9ed38d99', N'138898', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'c34788b5-3e3a-47be-b700-ac136d1c7d51', N'138858', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'095c58e0-d4bc-4060-96ec-b2f273bde261', N'88452', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'30743d58-8ba4-438b-a318-b4f60b850146', N'88449', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'4adc829e-3067-4226-b9e1-ba21cdc51caf', N'88423', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'd1eec598-6777-4228-83f0-be5005d36115', N'88440', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'f90e9589-1814-4c59-b658-c1fe703647f3', N'187952', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'b535df05-37aa-47cc-8866-c36a61110dff', N'88412', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'3f7d67d4-1f3f-4f58-8e4b-c88279312e6f', N'185284', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'6a3a5d68-0baf-4d66-8a88-c9cc5e856824', N'187844', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'2982dfb2-011d-4490-9e7e-d2c52e4aa6a7', N'187951', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'1f26048d-945e-4847-ba69-d4ce3c30491d', N'148580', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'07ea6a54-0124-4acd-8d2e-d8da054eb143', N'99185', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'00cb1d65-7936-4ec9-97cd-da9f1cdd5023', N'206153', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'5adea443-8285-4566-8b8a-e0547e1f6cd8', N'88444', N'بنزين ', N'')
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'725cfca3-e869-412b-9c34-e3a2a04404b3', N'88416', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'602613a4-1aa1-46fb-9524-e50661c296fd', N'187845', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'7ffddc67-948a-4879-85b4-ecc8c5c172af', N'88448', N'بنزين ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'f45302b0-0c64-4160-9de7-f8f8e4a3ab04', N'88414', N'سولار ', NULL)
GO
INSERT [dbo].[FuelCards] ([Id], [Number], [Name], [Registration]) VALUES (N'bf49ab71-427a-4339-a6e0-fd2b01ccb641', N'140506', N'بنزين', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'1b4bf68b-d76b-4ccf-a77b-012d832d7874', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(15319.00 AS Decimal(18, 2)), CAST(1417.00 AS Decimal(18, 2)), N'59cc5194-87f8-4b61-8481-0024098a7a51', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'59cc5194-87f8-4b61-8481-0024098a7a51', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'8ef81954-34e6-4777-b104-07b9192915c7', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(3384.00 AS Decimal(18, 2)), CAST(313.00 AS Decimal(18, 2)), N'f3338864-6ced-40ab-9f20-490704f49998', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'f3338864-6ced-40ab-9f20-490704f49998', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'e0c602b6-8164-4ec9-88bd-0985457d2115', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(12703.00 AS Decimal(18, 2)), CAST(117504.00 AS Decimal(18, 2)), N'27c951ef-d080-4e9c-8840-9d04e5a7706b', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'27c951ef-d080-4e9c-8840-9d04e5a7706b', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'b2ee796e-1af1-41ae-840b-09d597a805a1', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(22919.00 AS Decimal(18, 2)), CAST(2120.00 AS Decimal(18, 2)), N'febec3b4-729e-4b51-99d1-5abc7abbf8ff', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'febec3b4-729e-4b51-99d1-5abc7abbf8ff', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'40fb6f03-0a7a-479c-a579-0c62787ccb74', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(3946.00 AS Decimal(18, 2)), CAST(365.00 AS Decimal(18, 2)), N'cac6172d-db8b-402d-b6f1-8b0e631f1b70', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'cac6172d-db8b-402d-b6f1-8b0e631f1b70', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'bdd8b956-6404-4bf9-9bd2-130c3572b93f', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(9243.00 AS Decimal(18, 2)), CAST(855.00 AS Decimal(18, 2)), N'e5055e77-1581-43b4-8948-808d17c03cdc', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'e5055e77-1581-43b4-8948-808d17c03cdc', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'bef4d62c-a146-4452-b4e1-138424f2613e', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(200.00 AS Decimal(18, 2)), CAST(1450.00 AS Decimal(18, 2)), N'1a63578a-abcf-4c9c-be37-4df4cd41cb61', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'1a63578a-abcf-4c9c-be37-4df4cd41cb61', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'8097fb09-da20-4968-b482-14c869371ce0', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(24098.00 AS Decimal(18, 2)), CAST(2229.00 AS Decimal(18, 2)), N'3cb7d791-3884-4dc2-87bb-3832c0c76b9f', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'3cb7d791-3884-4dc2-87bb-3832c0c76b9f', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'25c794d8-ae1f-4679-8594-1753db4e3349', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(6690.00 AS Decimal(18, 2)), CAST(485.00 AS Decimal(18, 2)), N'c34788b5-3e3a-47be-b700-ac136d1c7d51', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'c34788b5-3e3a-47be-b700-ac136d1c7d51', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'e46692d3-5921-4bde-b0bf-1800d8e4db91', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(2162.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), N'e5055e77-1581-43b4-8948-808d17c03cdc', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'e5055e77-1581-43b4-8948-808d17c03cdc', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'18b0c9b4-fa9a-46e2-8209-1cb0da498a58', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(65448.00 AS Decimal(18, 2)), CAST(4745.00 AS Decimal(18, 2)), N'84afc3f2-f5a1-4c74-a917-4cc3dee71c92', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'84afc3f2-f5a1-4c74-a917-4cc3dee71c92', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'fc580346-554c-427e-9525-1f0fc41253b4', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(4138.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), N'f45302b0-0c64-4160-9de7-f8f8e4a3ab04', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'f45302b0-0c64-4160-9de7-f8f8e4a3ab04', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'1c2a39c5-9106-48ff-a4a8-21a454ac33d0', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(15190.00 AS Decimal(18, 2)), CAST(1405.00 AS Decimal(18, 2)), N'095c58e0-d4bc-4060-96ec-b2f273bde261', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'095c58e0-d4bc-4060-96ec-b2f273bde261', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'249c8595-7e16-408d-b2b8-2551e5800431', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(20580.00 AS Decimal(18, 2)), CAST(190363.00 AS Decimal(18, 2)), N'87a0a98b-2b93-42fa-b216-a7e222a3c47e', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'87a0a98b-2b93-42fa-b216-a7e222a3c47e', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'b15ca472-0632-4564-8eb9-26af866c5985', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(12304.00 AS Decimal(18, 2)), CAST(892.00 AS Decimal(18, 2)), N'725cfca3-e869-412b-9c34-e3a2a04404b3', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'725cfca3-e869-412b-9c34-e3a2a04404b3', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'6b226553-40e3-45a8-afec-26ca357afe79', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(15978.00 AS Decimal(18, 2)), CAST(1478.00 AS Decimal(18, 2)), N'7a24062f-038f-4f9f-8f7b-10c747a40968', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'7a24062f-038f-4f9f-8f7b-10c747a40968', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'8282d122-c6c5-40fa-8fa4-33627a775abe', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(8703.00 AS Decimal(18, 2)), CAST(805.00 AS Decimal(18, 2)), N'e3357092-4472-430b-8e52-715e794112df', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'e3357092-4472-430b-8e52-715e794112df', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'58ef0dac-9ccf-4574-9f18-336d5dbafa3a', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(14334.00 AS Decimal(18, 2)), CAST(148007.00 AS Decimal(18, 2)), N'aa089b5a-30e7-4f3d-a73c-3d878066fb8b', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'aa089b5a-30e7-4f3d-a73c-3d878066fb8b', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'5b32d37e-bd2f-40e1-bb46-369057acdaaa', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(4759.00 AS Decimal(18, 2)), CAST(345.00 AS Decimal(18, 2)), N'4adc829e-3067-4226-b9e1-ba21cdc51caf', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'4adc829e-3067-4226-b9e1-ba21cdc51caf', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'6fff8f97-2e41-4c19-a89d-36b1b66361c4', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(14965.00 AS Decimal(18, 2)), CAST(1085.00 AS Decimal(18, 2)), N'1f26048d-945e-4847-ba69-d4ce3c30491d', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'1f26048d-945e-4847-ba69-d4ce3c30491d', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'add6e46e-092c-4ae0-812e-37e077db3413', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(92760.00 AS Decimal(18, 2)), CAST(6725.00 AS Decimal(18, 2)), N'e0ffa888-eca9-4ddd-81a0-20517f293f32', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'e0ffa888-eca9-4ddd-81a0-20517f293f32', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'26d7d0e9-f65e-482e-88bb-3828a1608bca', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(28965.00 AS Decimal(18, 2)), CAST(2100.00 AS Decimal(18, 2)), N'02d27c34-c4df-4f70-b618-9d20a7122d6e', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'02d27c34-c4df-4f70-b618-9d20a7122d6e', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'123a936c-80f4-4cdb-93f4-39399581b887', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(2791.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), N'bf49ab71-427a-4339-a6e0-fd2b01ccb641', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'bf49ab71-427a-4339-a6e0-fd2b01ccb641', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'b888a35a-68dc-4e47-8c67-3bfa6e76a68f', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(60497.00 AS Decimal(18, 2)), CAST(4386.00 AS Decimal(18, 2)), N'da13276e-08ad-430b-a16e-7c00b9c3a6ee', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'da13276e-08ad-430b-a16e-7c00b9c3a6ee', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'0680d7e6-c158-4bed-a7f1-4661e0701773', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(15351.00 AS Decimal(18, 2)), CAST(1600.00 AS Decimal(18, 2)), N'30743d58-8ba4-438b-a318-b4f60b850146', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'30743d58-8ba4-438b-a318-b4f60b850146', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'af41c4d5-1474-449f-bfd3-4cd400991249', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(3395.00 AS Decimal(18, 2)), CAST(314.00 AS Decimal(18, 2)), N'3cb7d791-3884-4dc2-87bb-3832c0c76b9f', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'3cb7d791-3884-4dc2-87bb-3832c0c76b9f', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'd86863b8-43da-4435-8273-56f78ffb65b2', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(3243.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), N'59cc5194-87f8-4b61-8481-0024098a7a51', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'59cc5194-87f8-4b61-8481-0024098a7a51', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'5555dcab-5678-43ab-bd73-59fd0ab3ec45', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(6552.00 AS Decimal(18, 2)), CAST(475.00 AS Decimal(18, 2)), N'07ea6a54-0124-4acd-8d2e-d8da054eb143', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'07ea6a54-0124-4acd-8d2e-d8da054eb143', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'4c9f3199-8e76-48d5-bb38-5a9c6a53e258', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(42827.00 AS Decimal(18, 2)), CAST(3105.00 AS Decimal(18, 2)), N'e1640fa4-cc37-4ce5-8b03-04d7e59cb71c', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'e1640fa4-cc37-4ce5-8b03-04d7e59cb71c', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'0f75dc58-ccfd-434d-b24e-60888dc612fd', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(7138.00 AS Decimal(18, 2)), CAST(66030.00 AS Decimal(18, 2)), N'f3338864-6ced-40ab-9f20-490704f49998', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'f3338864-6ced-40ab-9f20-490704f49998', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'82dee42f-1650-4bf6-86a1-6478ff762930', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(5241.00 AS Decimal(18, 2)), CAST(380.00 AS Decimal(18, 2)), N'aaf26a2d-8246-45e9-ae5c-089c6dda296f', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'aaf26a2d-8246-45e9-ae5c-089c6dda296f', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'ff095faa-b0ee-4288-90f2-6997a7519e72', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(13330.00 AS Decimal(18, 2)), CAST(1233.00 AS Decimal(18, 2)), N'f9233b79-c126-4872-9628-2d866b7a200e', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'f9233b79-c126-4872-9628-2d866b7a200e', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'95057a44-18fe-4f27-8145-69e38d2cb410', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(12702.00 AS Decimal(18, 2)), CAST(1175.00 AS Decimal(18, 2)), N'd8730201-0d2d-41e1-a25e-a20f2bdcbca9', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'd8730201-0d2d-41e1-a25e-a20f2bdcbca9', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'5db8e98b-5be0-4473-a582-6a2dddbd36f5', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(13297.00 AS Decimal(18, 2)), CAST(1230.00 AS Decimal(18, 2)), N'2982dfb2-011d-4490-9e7e-d2c52e4aa6a7', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'2982dfb2-011d-4490-9e7e-d2c52e4aa6a7', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'e9ecec12-cbda-4582-bcc3-6d0e0ba86b4b', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(69905.00 AS Decimal(18, 2)), CAST(5068.00 AS Decimal(18, 2)), N'3f7d67d4-1f3f-4f58-8e4b-c88279312e6f', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'3f7d67d4-1f3f-4f58-8e4b-c88279312e6f', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'2471a73a-6433-496c-a4ef-6e206c65b06f', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(23753.00 AS Decimal(18, 2)), CAST(219699.00 AS Decimal(18, 2)), N'db9cb7a2-9fda-46fe-b82a-3b57fbb2054e', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'db9cb7a2-9fda-46fe-b82a-3b57fbb2054e', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'37531078-4111-4f8e-8fc9-710e5069bcf7', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(18325.00 AS Decimal(18, 2)), CAST(1695.00 AS Decimal(18, 2)), N'5adea443-8285-4566-8b8a-e0547e1f6cd8', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'5adea443-8285-4566-8b8a-e0547e1f6cd8', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'56eecb40-2393-48dc-9ea2-78fffa31eb90', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(13655.00 AS Decimal(18, 2)), CAST(990.00 AS Decimal(18, 2)), N'e0ffa888-eca9-4ddd-81a0-20517f293f32', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'e0ffa888-eca9-4ddd-81a0-20517f293f32', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'b4f08145-3314-4f4d-9d2c-7cc3a7c1aecf', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(61170.00 AS Decimal(18, 2)), CAST(4435.00 AS Decimal(18, 2)), N'4adc829e-3067-4226-b9e1-ba21cdc51caf', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'4adc829e-3067-4226-b9e1-ba21cdc51caf', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'78d4e0cd-d5b3-4e2a-8ced-850596dc4ffb', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(7379.00 AS Decimal(18, 2)), CAST(535.00 AS Decimal(18, 2)), N'9a1696b9-a03e-468d-9f56-51d62124e39b', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'9a1696b9-a03e-468d-9f56-51d62124e39b', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'73119323-b791-4144-9e17-85bb9bd3c40b', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(21406.00 AS Decimal(18, 2)), CAST(1980.00 AS Decimal(18, 2)), N'9835f2f0-96ea-4154-a429-599ac437befc', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'9835f2f0-96ea-4154-a429-599ac437befc', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'e0de5417-87f7-48e1-8ae7-8af6d7293d47', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(5027.00 AS Decimal(18, 2)), CAST(465.00 AS Decimal(18, 2)), N'9835f2f0-96ea-4154-a429-599ac437befc', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'9835f2f0-96ea-4154-a429-599ac437befc', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'cadf83f5-82b2-4250-9fb4-8bdc94df2ec2', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(5862.00 AS Decimal(18, 2)), CAST(425.00 AS Decimal(18, 2)), N'da13276e-08ad-430b-a16e-7c00b9c3a6ee', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'da13276e-08ad-430b-a16e-7c00b9c3a6ee', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'f8c2e121-efbb-43e5-b5eb-8d9d168e0d1d', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(2207.00 AS Decimal(18, 2)), CAST(160.00 AS Decimal(18, 2)), N'f45302b0-0c64-4160-9de7-f8f8e4a3ab04', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'f45302b0-0c64-4160-9de7-f8f8e4a3ab04', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'ed06b0b5-ed07-4a59-a753-8e575311f568', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(8649.00 AS Decimal(18, 2)), CAST(800.00 AS Decimal(18, 2)), N'31652916-d092-460c-aae1-697c84572e0b', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'31652916-d092-460c-aae1-697c84572e0b', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'6f15e735-e10d-4c54-bbca-8e670290aa9c', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(95653.00 AS Decimal(18, 2)), CAST(6935.00 AS Decimal(18, 2)), N'9a1696b9-a03e-468d-9f56-51d62124e39b', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'9a1696b9-a03e-468d-9f56-51d62124e39b', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'1689e877-4add-4de5-bc7d-91567257dbdc', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(4414.00 AS Decimal(18, 2)), CAST(320.00 AS Decimal(18, 2)), N'0f1c705d-169d-410e-b222-4da960b7bc98', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'0f1c705d-169d-410e-b222-4da960b7bc98', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'99b55839-87bd-440e-adc9-9208a3303f09', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(176.00 AS Decimal(18, 2)), CAST(1628.00 AS Decimal(18, 2)), N'7ffddc67-948a-4879-85b4-ecc8c5c172af', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'7ffddc67-948a-4879-85b4-ecc8c5c172af', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'8bb348ef-eccb-4f36-8952-92b35bb128d7', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(15460.00 AS Decimal(18, 2)), CAST(1430.00 AS Decimal(18, 2)), N'd1eec598-6777-4228-83f0-be5005d36115', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'd1eec598-6777-4228-83f0-be5005d36115', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'6e5be6ea-ed74-44c2-9c63-9566cf42ef88', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(6966.00 AS Decimal(18, 2)), CAST(505.00 AS Decimal(18, 2)), N'2f5ddb67-5647-44cf-b093-8fd2432695b6', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'2f5ddb67-5647-44cf-b093-8fd2432695b6', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'2f23b68d-edf7-41a2-a473-9a961873c571', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(72209.00 AS Decimal(18, 2)), CAST(5235.00 AS Decimal(18, 2)), N'1f26048d-945e-4847-ba69-d4ce3c30491d', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'1f26048d-945e-4847-ba69-d4ce3c30491d', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'a5867236-e645-4189-b3f4-9bb4d9ff652f', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(75170.00 AS Decimal(18, 2)), CAST(5450.00 AS Decimal(18, 2)), N'44b6d5ca-9440-4d42-83bc-50c65c2de726', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'44b6d5ca-9440-4d42-83bc-50c65c2de726', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'884e8c31-7910-4472-b032-9dfe420503ce', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(60346.00 AS Decimal(18, 2)), CAST(4375.00 AS Decimal(18, 2)), N'00cb1d65-7936-4ec9-97cd-da9f1cdd5023', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'00cb1d65-7936-4ec9-97cd-da9f1cdd5023', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'79a5a617-4a60-4b86-b2c0-a4ee2e7e6d86', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(7862.00 AS Decimal(18, 2)), CAST(570.00 AS Decimal(18, 2)), N'85872c47-43a5-4332-8419-511737ed049a', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'85872c47-43a5-4332-8419-511737ed049a', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'b1466fce-e259-4b13-a0e8-a6a003ca71a4', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(53724.00 AS Decimal(18, 2)), CAST(3895.00 AS Decimal(18, 2)), N'b53879f0-f30a-4142-83f0-ab9d204c5234', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'b53879f0-f30a-4142-83f0-ab9d204c5234', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'5fd2006e-d2dd-4cfd-ac2f-a6b63a49c61b', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(74486.00 AS Decimal(18, 2)), CAST(5400.00 AS Decimal(18, 2)), N'2f5ddb67-5647-44cf-b093-8fd2432695b6', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'2f5ddb67-5647-44cf-b093-8fd2432695b6', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'9f12ecb2-2fd5-435c-8c5e-b128a4b4dc9c', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(12483.00 AS Decimal(18, 2)), CAST(905.00 AS Decimal(18, 2)), N'ce60c3fd-17da-4655-9632-65d56796e274', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'ce60c3fd-17da-4655-9632-65d56796e274', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'd612b179-f1d5-435d-be62-b25398883fc4', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(7586.00 AS Decimal(18, 2)), CAST(550.00 AS Decimal(18, 2)), N'0c14c073-eb74-41de-9946-6cf959f06500', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'0c14c073-eb74-41de-9946-6cf959f06500', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'fc08f66e-268d-4d5c-b249-b2a70977c8d1', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(3243.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), N'd8730201-0d2d-41e1-a25e-a20f2bdcbca9', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'd8730201-0d2d-41e1-a25e-a20f2bdcbca9', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'4cde3515-90d2-4c56-b1f7-b5b3d226e093', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(64965.00 AS Decimal(18, 2)), CAST(4710.00 AS Decimal(18, 2)), N'0f1c705d-169d-410e-b222-4da960b7bc98', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'0f1c705d-169d-410e-b222-4da960b7bc98', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'a5db64dc-ca42-42fb-871b-ba02e5658b32', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(61378.00 AS Decimal(18, 2)), CAST(4450.00 AS Decimal(18, 2)), N'0c14c073-eb74-41de-9946-6cf959f06500', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'0c14c073-eb74-41de-9946-6cf959f06500', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'd43ac20c-bd5d-49d9-8a09-bc25880d6643', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(19945.00 AS Decimal(18, 2)), CAST(1845.00 AS Decimal(18, 2)), N'602613a4-1aa1-46fb-9524-e50661c296fd', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'602613a4-1aa1-46fb-9524-e50661c296fd', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'84a76a80-0c70-4e0b-b94b-c1c4ae2ad52a', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(3243.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), N'e3357092-4472-430b-8e52-715e794112df', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'e3357092-4472-430b-8e52-715e794112df', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'60dc8f5a-a250-43b5-af9d-c235e10e4065', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(12584.00 AS Decimal(18, 2)), CAST(1164.00 AS Decimal(18, 2)), N'ff9e1912-94be-4f26-9d5f-475373234a44', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'ff9e1912-94be-4f26-9d5f-475373234a44', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'fd46258f-e95a-4523-bc85-c274de174d8d', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(3814.00 AS Decimal(18, 2)), CAST(410.00 AS Decimal(18, 2)), N'aa089b5a-30e7-4f3d-a73c-3d878066fb8b', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'aa089b5a-30e7-4f3d-a73c-3d878066fb8b', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'2066e612-3727-43d3-97b4-c689052940c8', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(5379.00 AS Decimal(18, 2)), CAST(390.00 AS Decimal(18, 2)), N'44b6d5ca-9440-4d42-83bc-50c65c2de726', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'44b6d5ca-9440-4d42-83bc-50c65c2de726', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'1d456269-368a-45f4-9735-c84e1001b384', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(4539.00 AS Decimal(18, 2)), CAST(41990.00 AS Decimal(18, 2)), N'7d969004-d881-4e65-83e3-3c02a7667fe2', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'7d969004-d881-4e65-83e3-3c02a7667fe2', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'8aecb91b-9ce5-4bbb-ade7-c90d5b4c560f', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(14486.00 AS Decimal(18, 2)), CAST(1340.00 AS Decimal(18, 2)), N'bf49ab71-427a-4339-a6e0-fd2b01ccb641', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'bf49ab71-427a-4339-a6e0-fd2b01ccb641', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'd05f1d59-0a49-4995-8337-e25d69238dba', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(13311.00 AS Decimal(18, 2)), CAST(965.00 AS Decimal(18, 2)), N'629fceac-bee0-4b54-91b6-19b29664c629', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'629fceac-bee0-4b54-91b6-19b29664c629', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'f193509c-d573-4e8a-ac25-e5c821094f07', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(4324.00 AS Decimal(18, 2)), CAST(400.00 AS Decimal(18, 2)), N'27c951ef-d080-4e9c-8840-9d04e5a7706b', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'27c951ef-d080-4e9c-8840-9d04e5a7706b', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'd3e5acb2-3e28-437a-a7e7-e7ac7ec1d302', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(4138.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), N'b535df05-37aa-47cc-8866-c36a61110dff', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'b535df05-37aa-47cc-8866-c36a61110dff', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'56608ae1-ed9f-4a3d-b497-e8704c410737', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(11104.00 AS Decimal(18, 2)), CAST(805.00 AS Decimal(18, 2)), N'4eb7c504-1c12-4a84-aede-65608c8e5613', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'4eb7c504-1c12-4a84-aede-65608c8e5613', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'e1caa45b-1f06-48e0-9fb3-ec56b12dd024', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(59101.00 AS Decimal(18, 2)), CAST(4285.00 AS Decimal(18, 2)), N'f90e9589-1814-4c59-b658-c1fe703647f3', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'f90e9589-1814-4c59-b658-c1fe703647f3', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'0d4a49b3-2c13-433a-8fe7-ec7a72593dcd', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(12070.00 AS Decimal(18, 2)), CAST(87501.00 AS Decimal(18, 2)), N'6acc7c2f-29fe-49ea-88d9-92940f04836a', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'6acc7c2f-29fe-49ea-88d9-92940f04836a', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'95ecd9be-1471-4007-8f80-ee50e860b4ea', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(6828.00 AS Decimal(18, 2)), CAST(495.00 AS Decimal(18, 2)), N'3f7d67d4-1f3f-4f58-8e4b-c88279312e6f', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'3f7d67d4-1f3f-4f58-8e4b-c88279312e6f', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'ba7fb91b-4e6c-45f2-b427-ef0999f13c68', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(11903.00 AS Decimal(18, 2)), CAST(1101.00 AS Decimal(18, 2)), N'6a3a5d68-0baf-4d66-8a88-c9cc5e856824', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'6a3a5d68-0baf-4d66-8a88-c9cc5e856824', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'2ba5f98e-9007-4f09-b24d-f111603c0ad9', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(86210.00 AS Decimal(18, 2)), CAST(6250.00 AS Decimal(18, 2)), N'07ea6a54-0124-4acd-8d2e-d8da054eb143', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'07ea6a54-0124-4acd-8d2e-d8da054eb143', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'5525bbf8-343a-4288-ad17-f2870e64849b', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(67312.00 AS Decimal(18, 2)), CAST(4880.00 AS Decimal(18, 2)), N'c34788b5-3e3a-47be-b700-ac136d1c7d51', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'c34788b5-3e3a-47be-b700-ac136d1c7d51', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'a961d7c8-18cd-454c-adb9-f7879d40cca2', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(28056.00 AS Decimal(18, 2)), CAST(259522.00 AS Decimal(18, 2)), N'7d969004-d881-4e65-83e3-3c02a7667fe2', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'7d969004-d881-4e65-83e3-3c02a7667fe2', N'9bfb506e-73b1-409c-a925-dbf9f841e559', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'166c1952-c839-4dba-8c90-fa51b7c3f999', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(25642.00 AS Decimal(18, 2)), CAST(1859.00 AS Decimal(18, 2)), N'4eb7c504-1c12-4a84-aede-65608c8e5613', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'4eb7c504-1c12-4a84-aede-65608c8e5613', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'686880cc-fdc7-44ca-9799-fa552bf958e9', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(5379.00 AS Decimal(18, 2)), CAST(390.00 AS Decimal(18, 2)), N'84afc3f2-f5a1-4c74-a917-4cc3dee71c92', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'84afc3f2-f5a1-4c74-a917-4cc3dee71c92', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
INSERT [dbo].[FuelConsumptions] ([Id], [ConsumptionDate], [TotalConsumedQuanityInLiteres], [TotalAmountInEGP], [FuelCardId], [PeriodId], [VehicleId], [FuelTypeId], [Notes], [Vehicle_Id]) VALUES (N'56f7e1ed-d721-4ccb-a084-ffbd9336d77b', CAST(N'2022-10-01 00:00:00.000' AS DateTime), CAST(56277.00 AS Decimal(18, 2)), CAST(4080.00 AS Decimal(18, 2)), N'b535df05-37aa-47cc-8866-c36a61110dff', N'43d7fe81-aa30-4d4a-aa84-c29c86ae6f32', N'b535df05-37aa-47cc-8866-c36a61110dff', N'ab57c5ec-6b01-4790-964e-ce393c747e0a', N'', NULL)
GO
SET IDENTITY_INSERT [dbo].[SparePartsBills] ON 

GO
INSERT [dbo].[SparePartsBills] ([Id], [Number], [BillDate], [Repairs], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'ace0b4c7-b780-48ad-995d-545b7b708f4e', 1, CAST(N'2022-10-31 14:41:41.737' AS DateTime), N'KM 192000/ تم الاصلاح بالورشه داخل الشركه  بدون مصنعيات ويتم تحمل المستخدم للسياره النسبه المتفق عليه  ', N'095c58e0-d4bc-4060-96ec-b2f273bde261', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[SparePartsBills] ([Id], [Number], [BillDate], [Repairs], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'f40d639a-cc64-44cd-9748-60f8646402dc', 4, CAST(N'2022-11-01 10:43:57.633' AS DateTime), N' km  45000     تم عمل دوره غسيل كامله للموتورووضع جركن مياه خضراء موبيل  و تسليك الرادياتير و تغير غطاء رادياتير ', N'602613a4-1aa1-46fb-9524-e50661c296fd', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[SparePartsBills] ([Id], [Number], [BillDate], [Repairs], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'14cb8610-5af1-443b-911d-cb773bfe4ec8', 6, CAST(N'2022-11-02 13:15:56.880' AS DateTime), N'تم التركيب داخل الورشه (الفني  رمضان) ', N'3cb7d791-3884-4dc2-87bb-3832c0c76b9f', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[SparePartsBills] ([Id], [Number], [BillDate], [Repairs], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'49a2a409-3948-447d-9b28-cc9792871dff', 2, CAST(N'2022-10-31 15:29:52.440' AS DateTime), N'KM 120000/  تم تغير البطاريه بسبب تلفها  ( عمر أفتراضي ) و تم فحص الشحن حاليا بحاله جيده جدا 14 فولت ', N'9835f2f0-96ea-4154-a429-599ac437befc', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[SparePartsBills] ([Id], [Number], [BillDate], [Repairs], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'e7409a2f-88dd-4622-9e25-ebdad424a6b4', 5, CAST(N'2022-11-02 13:11:00.360' AS DateTime), N'تم التركيب داخل الشركه كم عداد 165000 ', N'59cc5194-87f8-4b61-8481-0024098a7a51', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
SET IDENTITY_INSERT [dbo].[SparePartsBills] OFF
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'199298aa-d6dd-4f37-a09d-12ac1606288a', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(445728.00 AS Decimal(18, 2)), NULL, N'2f5ddb67-5647-44cf-b093-8fd2432695b6', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'64d27d8f-f01f-4f46-a8bd-1570f9944c02', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(582286.00 AS Decimal(18, 2)), NULL, N'0c14c073-eb74-41de-9946-6cf959f06500', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'f6447eaf-6ae8-4d7d-a0c6-1594e024060b', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(55436.00 AS Decimal(18, 2)), NULL, N'27c951ef-d080-4e9c-8840-9d04e5a7706b', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'bc2d4488-b384-46ae-b468-1f77e3dd3afe', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(333106.00 AS Decimal(18, 2)), NULL, N'c34788b5-3e3a-47be-b700-ac136d1c7d51', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'c157fb4b-4ca1-444c-83b1-22c5ac24a098', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(78557.00 AS Decimal(18, 2)), NULL, N'9835f2f0-96ea-4154-a429-599ac437befc', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'950a35d0-a29f-459e-8e2b-28544ecaf8e3', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(98557.00 AS Decimal(18, 2)), NULL, N'07ea6a54-0124-4acd-8d2e-d8da054eb143', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'5bbd1ef7-5257-4fce-9e31-2ce3223d85dc', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(313343.00 AS Decimal(18, 2)), NULL, N'e3357092-4472-430b-8e52-715e794112df', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'ad68023e-0455-4893-bb26-3a7aa98dcb23', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(125000.00 AS Decimal(18, 2)), NULL, N'd8730201-0d2d-41e1-a25e-a20f2bdcbca9', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'db2e5cc9-bfe2-4e2a-b544-3f7ccead55ad', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(196847.00 AS Decimal(18, 2)), NULL, N'7d969004-d881-4e65-83e3-3c02a7667fe2', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'150f45a2-e39b-4fe7-8b40-56fd4b11639e', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(480418.00 AS Decimal(18, 2)), NULL, N'84afc3f2-f5a1-4c74-a917-4cc3dee71c92', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'ce3e23f0-55d7-43c3-a64e-5d1c730cb3b3', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(626531.00 AS Decimal(18, 2)), NULL, N'e0ffa888-eca9-4ddd-81a0-20517f293f32', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'fa217437-6cee-4eeb-bf80-68b8a6cfe54f', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(77276.00 AS Decimal(18, 2)), NULL, N'e744bfcc-6c54-45c8-ac36-02de9525f676', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'd62635c4-685c-4e95-b720-84ae9e316f50', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(364800.00 AS Decimal(18, 2)), NULL, N'da13276e-08ad-430b-a16e-7c00b9c3a6ee', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'd0d8540a-77ae-492b-9547-8ef646e62281', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(44115.00 AS Decimal(18, 2)), NULL, N'bf49ab71-427a-4339-a6e0-fd2b01ccb641', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'07eb012b-6864-4861-bb9d-a283c0714879', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(509113.00 AS Decimal(18, 2)), NULL, N'3f7d67d4-1f3f-4f58-8e4b-c88279312e6f', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'2f8e540f-f967-404c-abec-b104541904cd', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(2222222.00 AS Decimal(18, 2)), NULL, N'e5055e77-1581-43b4-8948-808d17c03cdc', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'0181afbb-1668-4a71-be3b-b3f7f0b7bde4', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(45436.00 AS Decimal(18, 2)), NULL, N'aa089b5a-30e7-4f3d-a73c-3d878066fb8b', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'd1419402-3f2b-4554-93df-bb96c3691626', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(378390.00 AS Decimal(18, 2)), NULL, N'44b6d5ca-9440-4d42-83bc-50c65c2de726', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'b2e9c8f0-aa0e-40b2-b035-be370e1777dd', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(348132.00 AS Decimal(18, 2)), NULL, N'9a1696b9-a03e-468d-9f56-51d62124e39b', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'28750497-185d-4d49-9e17-ce867390c1a3', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(165279.00 AS Decimal(18, 2)), NULL, N'59cc5194-87f8-4b61-8481-0024098a7a51', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'90e5e107-cd24-4ecb-b443-ea21df570401', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(249949.00 AS Decimal(18, 2)), NULL, N'3cb7d791-3884-4dc2-87bb-3832c0c76b9f', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'd3c40baa-b7bd-4197-ac15-f1bd1ec0b658', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(68593.00 AS Decimal(18, 2)), NULL, N'f3338864-6ced-40ab-9f20-490704f49998', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[VehicleKilometerReadings] ([Id], [ReadingDate], [Reading], [Notes], [VehicleId], [PeriodId], [Vehicle_Id]) VALUES (N'8a8e7f6d-8a08-489d-b42a-f4b0414d9da3', CAST(N'2022-11-01 00:00:00.000' AS DateTime), CAST(344323.00 AS Decimal(18, 2)), NULL, N'1f26048d-945e-4847-ba69-d4ce3c30491d', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', NULL)
GO
INSERT [dbo].[ViolationTypes] ([Id], [Name], [Description], [IsEnabled]) VALUES (N'7769573a-d240-45bf-8b0e-585238546814', N'Speed Violation', N'مخالفة السرعة المقررة', 1)
GO
SET IDENTITY_INSERT [dbo].[InternalMemos] ON 

GO
INSERT [dbo].[InternalMemos] ([Id], [Number], [MemoDate], [Header], [Content], [VehicleId], [PeriodId]) VALUES (N'ad7059e5-7eb3-4dfa-8101-a6648c5352e6', 2, CAST(N'2022-11-01 16:28:57.980' AS DateTime), N'صرف مبلغ ', N'حادث ىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىىى', N'602613a4-1aa1-46fb-9524-e50661c296fd', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[InternalMemos] ([Id], [Number], [MemoDate], [Header], [Content], [VehicleId], [PeriodId]) VALUES (N'a8050543-0058-4770-ae16-e9975c42a7c3', 3, CAST(N'2022-11-02 09:38:33.050' AS DateTime), N'mmnmn', N'kjlkhjbmnm/', N'602613a4-1aa1-46fb-9524-e50661c296fd', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
SET IDENTITY_INSERT [dbo].[InternalMemos] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseRequests] ON 

GO
INSERT [dbo].[PurchaseRequests] ([Id], [Number], [Description], [RequestDate], [State], [PeriodId], [VehicleId]) VALUES (N'e349d0c4-f3a1-4b21-86ee-1abbce8323d5', 2, NULL, CAST(N'2022-11-02 12:27:43.467' AS DateTime), N'Approved', N'205d6ee1-5596-4ed6-9c7c-1a2f48630280', N'602613a4-1aa1-46fb-9524-e50661c296fd')
GO
SET IDENTITY_INSERT [dbo].[PurchaseRequests] OFF
GO
INSERT [dbo].[Uoms] ([Id], [Code], [Name], [IsEnabled]) VALUES (N'50746399-5661-4cc9-b27d-902e64c12f15', N'EACH', N'عدد', 1)
GO
INSERT [dbo].[Uoms] ([Id], [Code], [Name], [IsEnabled]) VALUES (N'640767bd-a8ee-4c5c-a171-9c64042ed360', N'MT', N'متر', 1)
GO
INSERT [dbo].[Uoms] ([Id], [Code], [Name], [IsEnabled]) VALUES (N'0e85f5b1-8a37-4650-8420-c806b908ffaa', N'LT', N'Litre', 1)
GO
INSERT [dbo].[Uoms] ([Id], [Code], [Name], [IsEnabled]) VALUES (N'129ecb80-c03a-4a68-98a4-df460d775520', N'KG', N'Kilogram', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'6f9e11a6-4661-45ed-b145-086cec629ef0', N'عوامه جاز شيفورليه 220', N'عوامه جاز شيفورليه 220', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'1cb1dffa-e1d7-4877-aae0-0f06b76bf726', N'خرطوم فايز فيرنا العاشر ', N'خرطوم فايز فيرنا العاشر ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'7f7f2d9c-c1e7-4a7a-9bdf-11133aff5853', N'فلتر زيت جامبو 230', N'فلتر زيت جامبو 230', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'8bc9ed08-c44f-42e7-8714-112af9b56061', N'تيل خلفي شيفورليه 230', N'تيل خلفي شيفورليه 230', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'f1a232e4-22dc-4657-ae52-112c1e472197', N'عوامه جاز شيفورليه 230', N'عوامه جاز شيفورليه 230', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'3a47d02c-b896-4c3f-9fce-13052d9b2a52', N'فلتر هواء تيوتا فان ', N'فلتر هواء تيوتا فان ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'd41f7531-22a0-41bd-8330-1574b5ed4551', N'سير كاتينه أفيو (العاشر )', N'سير كاتينه أفيو (العاشر )', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'f7fb2d0a-1780-42d2-8676-1ca198a45f70', N'زيت فتيس مانيوال ', N'زيت فتيس مانيوال ', N'0e85f5b1-8a37-4650-8420-c806b908ffaa', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'38a4cbdf-8af7-4bdb-8ae3-1e5e7b0f581e', N'شحم موبيل جريس توكيل ', N'شحم موبيل جريس توكيل ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'08882ba1-81f0-48f6-a9e4-1f8d16909d3f', N'زيت فتيس اوتوماتيك نيسان صني توكيل ', N'زيت فتيس اوتوماتيك نيسان صني توكيل ', N'0e85f5b1-8a37-4650-8420-c806b908ffaa', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'33bcb286-db58-4a37-82b6-21b4aecefb5e', N'فلتر هواء تيوتا ميكروباص', N'فلتر هواء تيوتا ميكروباص ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'1c04a163-f709-41b7-b4dd-21bae261e0a2', N'زيت موتور 4 لتر 5000', N'زيت موتور 4 لتر 5000', N'0e85f5b1-8a37-4650-8420-c806b908ffaa', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'cf33acc1-65b0-44fe-808b-2403f6b91e4f', N'كرتونه عمره جامبو 230', N'كرتونه عمره جامبو 230', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'68a05451-ce9f-476e-a6c0-25be838aedb1', N'فلتر بنزبن فيرنا ', N'فلتر بنزبن فيرنا ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'09b75e9d-a9ad-4480-838d-2970664729d5', N'فلتر جاز تيوتا فان', N'فلتر جاز تيوتا فان ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'9750bb4d-a49b-4d0d-8f24-2bf0d55c0556', N'سير مجموعه نيسان صني توكيل', N'سير مجموعه نيسان صني توكيل  ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'936d03a8-daab-4bbf-97e7-2fcffb413b8b', N'زجاج أمامي ميني باص ', N'زجاج أمامي ميني باص ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'0799db6c-588f-4dbe-86f3-3c974f26c5d3', N'كرتونه عمره جامبو 220', N'كرتونه عمره جامبو 220', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'414ba76f-fa15-4608-90e2-3e0685b72b9c', N'ىيسان صني فلتر فتيس أتوماتيك ', N'ىيسان صني فلتر فتيس أتوماتيك ', N'0e85f5b1-8a37-4650-8420-c806b908ffaa', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'6989237b-eb95-47be-acbf-438ed43f1f11', N'تيل أمامي شيفورليه 2230', N'تيل أمامي شيفورليه 2230', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'fb9133d9-44dc-4fec-bf6f-46120c4a43f7', N'فلتر هواء نيسان صني توكيل', N'فلتر هواء نيسان صني توكيل  ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'6d6f4eb4-bada-4584-ba0a-4b15cb31f1e8', N'جركن مياه خضراء موبيل ( العاشر )', N'جركن مياه خضراء موبيل ( العاشر )', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'5c567b58-6bdb-446f-8c21-4bac197e0cbf', N'فلتر هواء جامبو 230', N'فلتر هواء جامبو 230', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'ebb95ff1-693c-4f0e-bcaa-4c1fb1d9da03', N'مجموعه سيور ( باور /دينامو/تكييف ) فيرنا كوري', N'مجموعه سيور ( باور /دينامو/تكييف ) فيرنا كوري', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'5baf3ce3-f09c-4afa-8fb7-4e5596238fea', N'فلتر جاز ميني باص توكيل ', N'فلتر جاز ميني باص توكيل ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'7474c995-4a79-4586-bdf5-4f49d6e3b8f0', N'تيل أمامي تيوتا ميكروباص العاشر  ', N' تيل أمامي تيوتا ميكروباص العاشر  ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'6b6b2cdb-008d-4259-a02f-512688c38d8a', N'فلتر زيت نيسان صني سوق ', N'فلتر زيت نيسان صني سوق ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'18ec850d-8c3e-4e07-9d6e-512c8b4aa0eb', N'فلتر بنزين MG', N'فلتر بنزين MG', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'38348ab0-00e5-409c-a559-5244b869dd4d', N'قلب طلمبه بنزبن فيرنا العاشر ', N'قلب طلمبه بنزبن فيرنا العاشر  ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'46940fab-22ee-499c-8a5e-52664e788191', N'بليه كاتينه افيو ( العاشر ) ', N'بليه كاتينه افيو ( العاشر )', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'03e2797f-d436-4d65-bc27-5922d915e39d', N'حساس كرنك فيرنا', N'حساس كرنك فيرنا ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'7c1c16ac-1ea7-44c0-a928-5cdb941b36f6', N'فلتر هواء فيرنا ', N'فلتر هواء فيرنا ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'225bb622-00e1-4116-a30f-5d4ba26db1c5', N'مياه تبريد توكيل نيسان صني  ', N'مياه تبريد توكيل نيسان صني  ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'8e4ede0c-8e8f-45ba-99ba-6041e762fbb5', N'فلتر جاز تيوتا ميكروباص ', N'فلتر جاز تيوتا ميكروباص ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'e6b8d91e-09ea-427b-b6cb-607b83a00d37', N'زجاج أمامي فيرنا ', N'زجاج أمامي فيرنا ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'c579e820-82b7-4bb5-97d2-6189ba90d817', N'لمبه H4 نيسان صني توكيل ', N'لمبه H4 نيسان صني توكيل ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'248af25f-059c-4ffc-a3a3-6475e49051d3', N'خامات توكيل ميني باص ', N'خامات توكيل ميني باص ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'78d51ad2-22f1-49f5-b55e-655586f793c3', N'تيل أمامي فيرنا حلاوه  ', N'تيل أمامي فيرنا حلاوه  ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'821d5ce0-f4c0-4ece-bae5-658977f9e6df', N'مسمار عجل فيرنا ', N'مسمار عجل فيرنا ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'0356fd23-a2cb-4269-9ea9-678fa7df77fb', N'فلتر هواء تيوتا  ميكروباص ', N'فلتر هواء تيوتا ميكروباص ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'17dc99f7-cfd7-4ecc-859f-6bbc82bbb8b6', N'زيت باكم MG', N'زيت باكم MG', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'0c6ab301-da09-4a04-ad82-6d2cf2ab828a', N'زيت R4X15W40توكيل ', N'زيت R4X15W40توكيل ', N'0e85f5b1-8a37-4650-8420-c806b908ffaa', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'ef70f492-02a1-4aa3-8c75-6e3d314e2a67', N'زيت موتور موبيل 10000توسان ', N'زيت موتور موبيل 10000توسان ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'9c785a41-8b29-47b2-a584-705e4a27d1d6', N'طقم جوان كامل اصلي شيفورليه 230', N'طقم جوان كامل اصلي شيفورليه 230', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'38b335ed-6531-4d52-80fe-7806de4d9786', N'تيل خلفي شيفورليه 220', N'تيل خلفي شيفورليه 220', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'a071dded-23e3-485a-91bd-780fbab526b5', N'سير مجموعه أفيو ( العاشر ) ', N'سير مجموعه أفيو ( العاشر ) ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'62752589-1746-40ad-b265-7c8d26808cdb', N'فلتر زيت ميني باص توكيل ', N'فلتر زيت ميني باص توكيل ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'd849da8a-c19e-48f6-8f9b-7f566b17579e', N'فلتر زيت جامبو 220', N'فلتر زيت جامبو 220', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'b9cfd965-50fc-4d79-9160-7febb2ea5139', N'زجاج أمامي mcv 220', N'زجاج أمامي mcv 220', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'9c21613b-e3aa-49a6-a371-8214d7d82f52', N'تسليك رادياتير فيرنا العاشر ', N'تسليك رادياتير فيرنا العاشر ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'cbed530f-12fb-4f91-a2e8-851a923ab229', N'فلتر زيت موتور MG', N'فلتر زيت موتور MG', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'e3c09730-bada-447f-96a8-877ff18d81d7', N'بوجيهات فيرنا ', N'بوجيهات فيرنا ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'cfc3c596-021e-4f44-ad0f-879ca9b7ec97', N'فلتر زيت موتور هيونداي فيرنا', N'فلتر زيت موتور هيونداي فيرنا', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'4c61750d-8327-4ac8-a49d-8f1183d9f4f2', N'زيت هيدروليك ', N'زيت هيدروليك ', N'0e85f5b1-8a37-4650-8420-c806b908ffaa', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'78643edb-178e-47c6-a09a-924cb7978b22', N'5زيت شل W30 MG', N'5زيت شل W30 MG', N'0e85f5b1-8a37-4650-8420-c806b908ffaa', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'504322bb-444f-47b3-9c0f-93560ac4d646', N'خراطه طنابير امامي فيرنا ', N'خراطه طنابير امامي فيرنا ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'1764a86b-47b9-41ab-a869-95fb5c3142f6', N'فلتر هواء نيسان دبل كابينه ', N'فلتر هواء نيسان دبل كابينه ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'bd21b4f3-9081-484e-93aa-9925ed267b05', N'حساس حراره حلاوه', N'حساس حراره حلاوه', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'2cf7bc51-d964-4959-9b5f-9a9cef277c8e', N'ورقه سوسته ', N'ورقه سوسته ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'7544dccc-9f95-4908-bacb-9b37c812a356', N'فوم تنظيف موتور MG', N'فوم تنظيف موتور MG', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'79b8b2fc-665a-4a26-b01d-9f37c66176a4', N'تيل خلفي فيرنا ', N'تيل خلفي فيرنا ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'678771c0-0355-431d-9dc2-a345ef92a8e2', N'فلتر فتيس أوتوماتيك فيرنا', N'فلتر فتيس أوتوماتيك فيرنا ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'd623647a-13d0-49ef-9e01-a44cd0824977', N'مسمار عجل امامي فيرنا حلاوه ', N'مسمار عجل امامي فيرنا حلاوه ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'28965300-8d01-49c0-8ba5-acf56873cb15', N'فلتر زيت توسان اصلي سوق ', N'فلتر زيت توسان اصلي سوق ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'65869aec-c7a2-4f42-8f74-ad31d4d34d42', N'فلتر زيت ديماكس ', N'فلتر زيت ديماكس ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'b498ef80-1ee4-45dc-8481-adf11d30cbc9', N'فلتر جاز نيسان دبل كابينه', N'فلتر جاز نيسان دبل كابينه', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'06099d94-56ea-4402-b12b-af88ce22baaa', N'غطاء رادياتير فيرنا العاشر  ', N'غطاء رادياتير فيرنا العاشر  ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'd53e4ae1-4710-4722-b1e0-b0b420af9ac7', N'سير مجموعه نيسان صني سوق', N'سير مجموعه نيسان صني سوق ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'cfe909ad-4ba2-4aa8-9d5f-b8ce0d3fc1eb', N'غطاء رادياتير فيرنا حلاوه ', N'غطاء رادياتير فيرنا حلاوه ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'58167af6-f1d2-479c-b75b-b9e37f2491d6', N'طلمبه بنزين كامله نيسان صني سوق  ', N'طلمبه بنزين كامله نيسان صني سوق  ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'b51bcce6-ec37-4ca8-9e8d-bde86a86df5d', N'فلتر جاز جامبو 230', N'فلتر جاز جامبو 230', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'2bf0a87b-9b57-4cb6-9c0d-be9355b16d39', N'فلتر هواء MG', N'فلتر هواء MG', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'c0cd8471-dde6-411e-80df-c9351cc20551', N'فلتر زيت تيوتا ميكروباص ', N'فلتر زيت تيوتا ميكروباص ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'27e29a36-e3e2-4ef9-bcc3-cb7e79eef0e5', N'بطاريه 70 أمبير أوبل ناصر ', N'بطاريه 70 أمبير أوبل ناصر ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'b8c3ce8c-2681-4a9a-b59c-cd1a226e19d3', N'فلتر هواء ديماكس ', N'فلتر هواء ديماكس ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'94a4f49a-ec1c-46de-a8f1-cd50b9d067e6', N'زيت موتور 10000 فيرنا ', N'زيت موتور 10000 فيرنا ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'6786e3f6-0dc2-4be9-abaa-cde19e142952', N'فلتر زيت نيسان صني توكيل ', N'فلتر زيت نيسان صني توكيل  ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'ff8c2b23-592a-4a06-b4e8-d3f78c413d15', N'تيل خلفي تيوتا ميكروباص العاشر ', N'تيل خلفي تيوتا ميكروباص العاشر ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'ced5bb06-60b8-48c9-a6be-d6ef96097d81', N'فلتر زيت نيسان دبل كابينه', N'فلتر زيت نيسان دبل كابينه', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'e8e17e35-534b-45e3-8164-d83b9c3d13d8', N'فلتر جاز ديماكس ', N'فلتر جاز ديماكس ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'bf6397cb-560d-405b-ba29-deea98211f7f', N'فلتر هواء نيسان صني سوق ', N'فلتر هواء نيسان صني سوق ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'1e63bc5e-850c-4382-b9e7-e539ce240d73', N'كاتينه أصلي فيرنا ', N'كاتينه أصلي فيرنا ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'05b45344-7a6c-408d-8164-e8f31030b208', N'زيت شل ديزل 5000', N'زيت شل ديزل 5000', N'0e85f5b1-8a37-4650-8420-c806b908ffaa', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'cb385862-37fc-4264-8b42-e9808854ae7f', N'زيت موتور نيسان صني 10000 توكيل ', N'زيت موتور نيسان صني 10000 توكيل ', N'0e85f5b1-8a37-4650-8420-c806b908ffaa', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'cc81caa1-102d-48a6-b1b9-f0f2719b02df', N'فلتر زيت تيوتا فان ', N'فلتر زيت تيوتا فان ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'7cdef4b8-ccc7-4d47-af7b-f401ccea4323', N'5W30 زيت موبيل 10000توسان ', N'5W30 زيت موبيل 10000توسان', N'0e85f5b1-8a37-4650-8420-c806b908ffaa', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'46318783-13c5-42af-9aec-f857f04822ea', N'تيل أمامي شيفورليه 220', N'تيل أمامي شيفورليه 220', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'e1679aa9-b051-4b5b-b8c9-f9220021c302', N'طقم جوان كامل أصلي شيفوليه 220', N'طقم جوان كامل أصلي شيفوليه 220', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'0a5cf9c5-19c0-48a2-9c55-f9ca85d83834', N'فلتر هواء جامبو 220', N'فلتر هواء جامبو 220', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'890f049a-7fca-46c7-ae80-fcdafb218997', N'خامات تنظيف MG', N'خامات تنظيف MG', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'7c31108b-f8e8-411e-9739-fd796ba07f88', N'فلتر زيت موتور توسان (سوق )', N'فلتر زيت موتور توسان (سوق )', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'4cb93e3b-61dc-4ed0-b1e2-fdbb054caa82', N'فلتر تكييف MG', N'فلتر تكييف MG', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[SpareParts] ([Id], [Code], [Name], [PrimaryUomId], [IsEnabled]) VALUES (N'fbe7135b-e862-4ce8-9ec6-fe59995d1482', N'زجاج أمامي أوبل ', N'زجاج أمامي أوبل ', N'50746399-5661-4cc9-b27d-902e64c12f15', 1)
GO
INSERT [dbo].[PurchaseRequestLines] ([Id], [RequestedQuantity], [Notes], [PurchaseRequestId], [SparePartId], [UomId]) VALUES (N'5674c81b-8655-4fdf-9bcd-798681ebd754', CAST(5.0000 AS Decimal(18, 4)), NULL, N'e349d0c4-f3a1-4b21-86ee-1abbce8323d5', N'e3c09730-bada-447f-96a8-877ff18d81d7', N'0e85f5b1-8a37-4650-8420-c806b908ffaa')
GO
INSERT [dbo].[PurchaseRequestLines] ([Id], [RequestedQuantity], [Notes], [PurchaseRequestId], [SparePartId], [UomId]) VALUES (N'a53d3cbb-e04b-4e35-82ea-af9ae8ff2d86', CAST(1.0000 AS Decimal(18, 4)), NULL, N'e349d0c4-f3a1-4b21-86ee-1abbce8323d5', N'94a4f49a-ec1c-46de-a8f1-cd50b9d067e6', N'0e85f5b1-8a37-4650-8420-c806b908ffaa')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'db5bd743-998d-456e-ac9b-04c6d796e19d', CAST(1090.00 AS Decimal(18, 2)), N'0e85f5b1-8a37-4650-8420-c806b908ffaa', N'7cdef4b8-ccc7-4d47-af7b-f401ccea4323', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'390b22ab-fe5d-441e-9faa-0a1f72a6aecc', CAST(50.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'd623647a-13d0-49ef-9e01-a44cd0824977', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'c87c41fd-d8bd-43ab-93bc-0a6a86520f29', CAST(550.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'46940fab-22ee-499c-8a5e-52664e788191', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'1f4aeeca-5c81-4976-8a44-16ed3ae54ff1', CAST(219.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'4cb93e3b-61dc-4ed0-b1e2-fdbb054caa82', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'ff32db18-f113-48a7-a835-1eb186f9cd69', CAST(450.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'd41f7531-22a0-41bd-8330-1574b5ed4551', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'7b37cd4a-944e-433a-854f-2d080338ede3', CAST(130.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'68a05451-ce9f-476e-a6c0-25be838aedb1', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'e4ff026d-f341-4a65-8782-3ba28209aff0', CAST(185.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'78d51ad2-22f1-49f5-b55e-655586f793c3', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'ed2f5491-e6be-46f2-ac00-3bdb5fcc1ad0', CAST(145.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'9c21613b-e3aa-49a6-a371-8214d7d82f52', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'ac117e3f-19cd-4710-8793-43f858304207', CAST(248.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'18ec850d-8c3e-4e07-9d6e-512c8b4aa0eb', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'5ab2a5af-3deb-4ac2-ac7b-44b96f414b72', CAST(1000.00 AS Decimal(18, 2)), N'0e85f5b1-8a37-4650-8420-c806b908ffaa', N'08882ba1-81f0-48f6-a9e4-1f8d16909d3f', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'23007df4-113a-4214-b03e-451c4b3d4dc5', CAST(30.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'1cb1dffa-e1d7-4877-aae0-0f06b76bf726', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'5c39b13c-8759-4a79-a287-47082a640406', CAST(150.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'cfc3c596-021e-4f44-ad0f-879ca9b7ec97', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'84284777-f383-46e9-9be4-551fc36edd82', CAST(456.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'bd21b4f3-9081-484e-93aa-9925ed267b05', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'b841fb2c-be7d-47f5-b622-5b922d0ef8dd', CAST(490.00 AS Decimal(18, 2)), N'0e85f5b1-8a37-4650-8420-c806b908ffaa', N'1c04a163-f709-41b7-b4dd-21bae261e0a2', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'0816f626-08de-4ed9-9c66-64022e23ae94', CAST(85.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'7c1c16ac-1ea7-44c0-a928-5cdb941b36f6', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'a1d9bd8c-e26d-44b8-9b06-690fed6049b5', CAST(834.44 AS Decimal(18, 2)), N'0e85f5b1-8a37-4650-8420-c806b908ffaa', N'0c6ab301-da09-4a04-ad82-6d2cf2ab828a', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'db147344-129f-4d0a-9964-698cbfa823f4', CAST(500.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'a071dded-23e3-485a-91bd-780fbab526b5', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'cab44236-582b-474b-933c-7867d4fde540', CAST(112.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'17dc99f7-cfd7-4ecc-859f-6bbc82bbb8b6', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'95648588-fb87-48e0-9c31-81cd636a017b', CAST(145.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'06099d94-56ea-4402-b12b-af88ce22baaa', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'65db6ce8-aa7e-4f55-a9e4-88b3e6795dac', CAST(350.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'6d6f4eb4-bada-4584-ba0a-4b15cb31f1e8', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'bef03d2a-8736-492d-9f54-8992b965d16f', CAST(17.23 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'38a4cbdf-8af7-4bdb-8ae3-1e5e7b0f581e', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'631bba83-9d41-49c3-afb2-9776460805c2', CAST(55.18 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'5baf3ce3-f09c-4afa-8fb7-4e5596238fea', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'adc6a190-9134-45f4-add9-999eea52de7f', CAST(1364.04 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'fbe7135b-e862-4ce8-9ec6-fe59995d1482', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'7347f7f6-fb38-49fb-9be6-9f8b81505868', CAST(273.60 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'28965300-8d01-49c0-8ba5-acf56873cb15', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'5b96cba9-f4bc-4f1b-827e-b488194320bc', CAST(1000.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'94a4f49a-ec1c-46de-a8f1-cd50b9d067e6', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'56539cd9-73da-4c60-83ae-c2dbcaaf74ce', CAST(250.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'd53e4ae1-4710-4722-b1e0-b0b420af9ac7', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'9a7fb222-1782-4ad4-a834-d7a751bb368d', CAST(150.91 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'62752589-1746-40ad-b265-7c8d26808cdb', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'bcbd7586-589a-40d3-833b-ed59e6202fc2', CAST(100.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'504322bb-444f-47b3-9c0f-93560ac4d646', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'b3a8a007-70e0-43b7-8858-f0d94db671f1', CAST(500.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'03e2797f-d436-4d65-bc27-5922d915e39d', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartPriceListLines] ([Id], [UnitPrice], [UomId], [SparePartId], [UomConversionRate], [SparePartsPriceList_Id]) VALUES (N'834a4174-711b-47f2-b224-fc81632f370a', CAST(1700.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'27e29a36-e3e2-4ef9-bcc3-cb7e79eef0e5', NULL, N'205d6ee1-5596-4ed6-9c7c-1a2f48630280')
GO
INSERT [dbo].[SparePartsBillLines] ([Id], [Quantity], [UomId], [SparePartId], [UnitPrice], [UomConversionRate], [Notes], [SparePartsBill_Id]) VALUES (N'a68115d0-b9b5-4f74-a6a6-13a9a4f96eeb', CAST(1.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'd623647a-13d0-49ef-9e01-a44cd0824977', CAST(50.00 AS Decimal(18, 2)), NULL, N'', N'ace0b4c7-b780-48ad-995d-545b7b708f4e')
GO
INSERT [dbo].[SparePartsBillLines] ([Id], [Quantity], [UomId], [SparePartId], [UnitPrice], [UomConversionRate], [Notes], [SparePartsBill_Id]) VALUES (N'9e13b31d-482a-496c-bfb9-23fa7f75e53c', CAST(1.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'94a4f49a-ec1c-46de-a8f1-cd50b9d067e6', CAST(1000.00 AS Decimal(18, 2)), NULL, N'', N'ace0b4c7-b780-48ad-995d-545b7b708f4e')
GO
INSERT [dbo].[SparePartsBillLines] ([Id], [Quantity], [UomId], [SparePartId], [UnitPrice], [UomConversionRate], [Notes], [SparePartsBill_Id]) VALUES (N'c87c5204-41fe-4933-933d-3392accf788a', CAST(1.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'46940fab-22ee-499c-8a5e-52664e788191', CAST(550.00 AS Decimal(18, 2)), NULL, N'', N'e7409a2f-88dd-4622-9e25-ebdad424a6b4')
GO
INSERT [dbo].[SparePartsBillLines] ([Id], [Quantity], [UomId], [SparePartId], [UnitPrice], [UomConversionRate], [Notes], [SparePartsBill_Id]) VALUES (N'f96cf6c6-d30d-4c4a-bd4b-3ae41dc9b2f2', CAST(1.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'504322bb-444f-47b3-9c0f-93560ac4d646', CAST(100.00 AS Decimal(18, 2)), NULL, N'', N'ace0b4c7-b780-48ad-995d-545b7b708f4e')
GO
INSERT [dbo].[SparePartsBillLines] ([Id], [Quantity], [UomId], [SparePartId], [UnitPrice], [UomConversionRate], [Notes], [SparePartsBill_Id]) VALUES (N'b6142b8d-3091-42d9-9fdf-44b6f3498c98', CAST(1.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'9c21613b-e3aa-49a6-a371-8214d7d82f52', CAST(145.00 AS Decimal(18, 2)), NULL, N'', N'f40d639a-cc64-44cd-9748-60f8646402dc')
GO
INSERT [dbo].[SparePartsBillLines] ([Id], [Quantity], [UomId], [SparePartId], [UnitPrice], [UomConversionRate], [Notes], [SparePartsBill_Id]) VALUES (N'f4c2946d-27c8-442b-8bdf-4e22a730b035', CAST(1.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'6d6f4eb4-bada-4584-ba0a-4b15cb31f1e8', CAST(350.00 AS Decimal(18, 2)), NULL, N'', N'f40d639a-cc64-44cd-9748-60f8646402dc')
GO
INSERT [dbo].[SparePartsBillLines] ([Id], [Quantity], [UomId], [SparePartId], [UnitPrice], [UomConversionRate], [Notes], [SparePartsBill_Id]) VALUES (N'7a749638-6b4e-4e0f-88c3-50e907ccc804', CAST(1.00 AS Decimal(18, 2)), N'0e85f5b1-8a37-4650-8420-c806b908ffaa', N'1c04a163-f709-41b7-b4dd-21bae261e0a2', CAST(490.00 AS Decimal(18, 2)), NULL, N'', N'e7409a2f-88dd-4622-9e25-ebdad424a6b4')
GO
INSERT [dbo].[SparePartsBillLines] ([Id], [Quantity], [UomId], [SparePartId], [UnitPrice], [UomConversionRate], [Notes], [SparePartsBill_Id]) VALUES (N'918f03f3-cc41-43b8-822c-8153230050a5', CAST(1.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'a071dded-23e3-485a-91bd-780fbab526b5', CAST(500.00 AS Decimal(18, 2)), NULL, N'', N'e7409a2f-88dd-4622-9e25-ebdad424a6b4')
GO
INSERT [dbo].[SparePartsBillLines] ([Id], [Quantity], [UomId], [SparePartId], [UnitPrice], [UomConversionRate], [Notes], [SparePartsBill_Id]) VALUES (N'53baf1b2-d0a9-41ee-ae74-944dbfdace8c', CAST(1.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'd41f7531-22a0-41bd-8330-1574b5ed4551', CAST(450.00 AS Decimal(18, 2)), NULL, N'', N'e7409a2f-88dd-4622-9e25-ebdad424a6b4')
GO
INSERT [dbo].[SparePartsBillLines] ([Id], [Quantity], [UomId], [SparePartId], [UnitPrice], [UomConversionRate], [Notes], [SparePartsBill_Id]) VALUES (N'7c97005c-e0a6-4d88-924a-9e1790b74fa2', CAST(1.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'7c1c16ac-1ea7-44c0-a928-5cdb941b36f6', CAST(85.00 AS Decimal(18, 2)), NULL, N'', N'ace0b4c7-b780-48ad-995d-545b7b708f4e')
GO
INSERT [dbo].[SparePartsBillLines] ([Id], [Quantity], [UomId], [SparePartId], [UnitPrice], [UomConversionRate], [Notes], [SparePartsBill_Id]) VALUES (N'7b5a8174-4965-4745-a495-a086189b2ed4', CAST(1.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'27e29a36-e3e2-4ef9-bcc3-cb7e79eef0e5', CAST(1700.00 AS Decimal(18, 2)), NULL, N'', N'49a2a409-3948-447d-9b28-cc9792871dff')
GO
INSERT [dbo].[SparePartsBillLines] ([Id], [Quantity], [UomId], [SparePartId], [UnitPrice], [UomConversionRate], [Notes], [SparePartsBill_Id]) VALUES (N'358a421d-2b77-49a4-90e2-a70ef387809d', CAST(1.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'78d51ad2-22f1-49f5-b55e-655586f793c3', CAST(185.00 AS Decimal(18, 2)), NULL, N'', N'ace0b4c7-b780-48ad-995d-545b7b708f4e')
GO
INSERT [dbo].[SparePartsBillLines] ([Id], [Quantity], [UomId], [SparePartId], [UnitPrice], [UomConversionRate], [Notes], [SparePartsBill_Id]) VALUES (N'2e6a9e71-ee59-41d8-877f-b5faaed3c24b', CAST(1.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'cfc3c596-021e-4f44-ad0f-879ca9b7ec97', CAST(150.00 AS Decimal(18, 2)), NULL, N'', N'ace0b4c7-b780-48ad-995d-545b7b708f4e')
GO
INSERT [dbo].[SparePartsBillLines] ([Id], [Quantity], [UomId], [SparePartId], [UnitPrice], [UomConversionRate], [Notes], [SparePartsBill_Id]) VALUES (N'c9648935-c98c-4b98-bf75-cf69220bcd0b', CAST(1.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'bd21b4f3-9081-484e-93aa-9925ed267b05', CAST(456.00 AS Decimal(18, 2)), NULL, N'', N'14cb8610-5af1-443b-911d-cb773bfe4ec8')
GO
INSERT [dbo].[SparePartsBillLines] ([Id], [Quantity], [UomId], [SparePartId], [UnitPrice], [UomConversionRate], [Notes], [SparePartsBill_Id]) VALUES (N'c2829495-dbf6-421f-9f36-e43561b3f893', CAST(1.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'68a05451-ce9f-476e-a6c0-25be838aedb1', CAST(130.00 AS Decimal(18, 2)), NULL, N'', N'ace0b4c7-b780-48ad-995d-545b7b708f4e')
GO
INSERT [dbo].[SparePartsBillLines] ([Id], [Quantity], [UomId], [SparePartId], [UnitPrice], [UomConversionRate], [Notes], [SparePartsBill_Id]) VALUES (N'2a7c6fca-937b-46a7-8bd6-f2efad3d68c4', CAST(1.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'03e2797f-d436-4d65-bc27-5922d915e39d', CAST(500.00 AS Decimal(18, 2)), NULL, N'', N'ace0b4c7-b780-48ad-995d-545b7b708f4e')
GO
INSERT [dbo].[SparePartsBillLines] ([Id], [Quantity], [UomId], [SparePartId], [UnitPrice], [UomConversionRate], [Notes], [SparePartsBill_Id]) VALUES (N'8a9e4437-2aa1-4249-a66b-fff45d062fd6', CAST(1.00 AS Decimal(18, 2)), N'50746399-5661-4cc9-b27d-902e64c12f15', N'06099d94-56ea-4402-b12b-af88ce22baaa', CAST(145.00 AS Decimal(18, 2)), NULL, N'', N'f40d639a-cc64-44cd-9748-60f8646402dc')
GO
COMMIT TRANSACTION T1;
GO

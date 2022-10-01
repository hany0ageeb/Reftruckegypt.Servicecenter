# Reftruckegypt.Servicecenter

# Models
------------------------------
VehicleCategory 
	id: GUID,
	name: string - unique - 250 Maxl Length - required
	description: string - 500 - not required
	validModels: List of all valid models in that category ??
	isLicenseRequired: Y/N
	isChassisNumberRequired: Y/N
	isFuelCardRequired: Y/N
------------
VehicleCategories {
	Forklift, 
	Truck, 
	Passenger, 
	Bus
}
	--------------------------------------------------------------------
VehicleModel
	id: GUID
	name: string - unique - 250 max length - required
	description: string max length 500 not required
	vehicleCategory: VehicleCategory - required
	FuelType: required
-----
VehicleModels{
	ميكروباص فوتون / Bus,
	ميكروباص تويوتا / Bus,
	أوتوبيس - شيفروليه - MCV / Bus,
	أوتوبيس - شيفروليه - خلف / Bus,
	ديماكس دبل كابينة / Truck,
	شيفرليه  - جامبو 5000 / Truck,
	شيفرليه ديماكس / Truck,
	ديماكس دبل كابينة / Truck,
	متسوبيشى كانتر / Truck,
	شيفرليه  - جامبو 8000 / Truck,
	مرسيدس شبل / Truck,
	نيسان دبل كابينة / Truck,
	 مرسيدس فان / Truck,
	تويوتا فان / Truck,
	هيونداى فيرنا - مانوال / Passenger,
	اسكودا أوكتافيا / Passenger,
	شيفرليه أفيو  / Passenger,
	هيونداى فيرنا - أوتوماتيك / Passenger,
	هيونداى توسان / Passeneger,
	نيسان صني  - N17 - أوتوماتيك / Passenger,
	Toyota / Passeneger,
	MG 5 / Passeneger,
	أوبل أستر / Passeneger
	TCM / Forklift,
	كاتربلر / Forklift,
	كوماتسو / Forklift
	
	
	
}
FuelType
	id: GUID,
	name: string - requirred - Max 200
	description: max 500 not required
	---------------------------------------------------------------------
VehicleLicense: not required for forklift

	motorNumber: string - required
	plateNumber: string - required
	licenseStartDate: Date
	licenseEndDate: Date
	fuelType: fuelType

	----------------------------------------------------------------------	
FuelCard:
	id: GUID
	name: string	required
	registration: string required
	vehicle: Vehicle
	----------------------------------------------------------------------
VehicleState: // الحالة العامة للمركبة
	id: GUID
	name: string - required - 250 max
	description: string
	-----------------------------------------------------------------------
Vehicle
	id: Guid
	category: VehicleCategory - required
	model: VehicleModel	- required
	chassisNumber: string - only required if vehicle model is not forklift
	license: list of licenses - empty fro forklift category
	fuelCard: FuelCard - not required for forklift category
	vehicleCode: string - required
	//مكان التشغبل
	// مكان الصيانة
	// المستخدم
	violations: list of violations
	initialKilometerReading
	WorkingState: {Broken, Working}
	--------------------------------------------------------------------------
Driver:
	id: Guid
	name: string - required
	licenseNumber: string - required
	licenseEndDate: date - required
	--------------------------------------------------------------------------
ViolationType
	id: GUID
	name: string max 250 required
	description: string max 500 not required
	// what else
	--------------------------------------------------------------------------
Violation:
	id: GUID
	type: ViolationType - required
	period: Required
	vehicle: required
	count: decimal
	--------------------------------------------------------------------------
Period:
	id: GUID
	name: string
	description: string
	fromDate: Date
	toDate: Date
	state: open/closed
	---------------------------------------------------------------------------
FuelConsumption: -- ASK Eng malak for some details
	id: GUID
	vehicel: required
	period: period
	toalConsumedquantityInLiteres: decimal
	totalamountInEGP: decimal
	lastKM: decimal
	consumption_100: decimal
ExternalWokshop:
	id: GUID
	name: string required 250 unique
	address:
	mobile:
	---------------------------------------------------------------------------------
ExternalMaintenaceBill:
	id:
	externalWorkshop: required
	date:date
	vehicle: required
	// بيان الاعمال: string
	amountInEGP: decimal
	notes: string 500 max not required
	---------------------------------------------------------------------------------
Uom:
	id:
	code:
	name:
	---------------------------------------------------------------------------------
uomConversion:
	id:
	from:
	to:
	rate:
	---------------------------------------------------------------------------------
SparePart:
	id:
	code:
	name:
	primary_uom_Id:
	---------------------------------------------------------------------------------
PriceList:
	id:
	period:
	notes:
	-------------------------------------------------------------------------------
PriceListLine:
	itemId:
	uomId:
	unitPrice: decimal
	notes:
	-----------------------------------------------------------------------------
InternalBillLines:
	id: GUID
	item_id:
	uom_id:
	quantity: decimal
	notes: string
	-----------------------------------------------------------------------------
InternalBill:
	id:	GUID
	date: date
	vehicel:
	kilometer:
	notes: string
	lines:
	---------------------------------------------------------------------------------
Fleet DownTime
	Malfunction	----
	Working		----
	
	
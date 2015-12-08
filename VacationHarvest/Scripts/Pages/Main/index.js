
angular.module('ptoApp', [])
	.constant('RecordType', {
		0: { cssClass: 'default', filter: 'default' },
		1: { cssClass: 'new-month', filter: 'newMonth' },
		2: { cssClass: 'sick-leave', filter: 'sickLeave' },
		3: { cssClass: 'unpaid', filter: 'unpaid' },
		4: { cssClass: 'vacation', filter: 'vacation' }
	})
	.filter('recordTypeClass', [
		'RecordType', function (RecordType) {
			return function (recordTypeId) {
				var result = RecordType[recordTypeId];
				return result ? result.cssClass : 'default';
			};
		}
	])
	.filter('prevYearClass', function () {
		return function (startDate) {
			var years = new Date(Date.now()).getFullYear() -(new Date(startDate)).getFullYear();
			return years > 0 ? 'prev-year': '';
			};
		}
	)
	.filter('timeDiff', function () {
			return function(date) {
				var endDate = new Date(Date.now());
				var startDate = new Date(date);
				if (startDate >= endDate) {
					return 'less than 1 month';
				}

				var years = endDate.getFullYear() - startDate.getFullYear();
				var months = endDate.getMonth() - startDate.getMonth();

				var days = endDate.getDate() - startDate.getDate();

				if (days < 0) {
					months--;
				}

				if (months < 0) {
					years--;
					months += 12;
				}

				var result = '';
				if (years > 0) {
					result = years.toString() + (years > 1 ? ' years ' : ' year ');
				}

				if (months > 0) {
					result = result + months.toString() + (months > 1 ? ' months ' : ' month ');
				}

				if (result === '') {
					result = 'less than 1 month';
				}

				return result;
			};
		}
	)
	.filter('byType', [
		'RecordType', function (RecordType) {
			return function (items, filters) {
				var out = [];
				angular.forEach(items, function (value) {
					var recordType = RecordType[value.RecordType];
					if (filters[recordType ? recordType.filter : 'default'] === true) {
						out.push(value);
					}
				});
				return out;
			};
		}
	])
	.controller('gridCtrl', [
		'$http', '$window', function ($http, $window) {
			var self = this;
			self.entries = [];
			self.hoursLeft = 0;
			self.sickHours = 0;
			self.unpaidHours = 0;
			self.usedHours = 0;
			self.startDate = Date.now();

			self.isLoading = true;
			self.filters = {
				'default': true,
				'newMonth': true,
				'vacation': true,
				'sickLeave': true,
				'unpaid': true
			};
			self.sortBy = 'StartDate';
			self.reverse = true;
			self.maximized = false;

			self.loadGridData = function () {
				self.isLoading = true;
				$http.post('/PtoDataHandler.ashx').then(function (response) {
					console.log(response.data);

					if (response.data.timeOut) {
						$window.location.href = 'Account/Login';
					}

					self.entries = response.data.entries;
					self.hoursLeft = response.data.hoursLeft;
					self.sickHours = response.data.sickHours;
					self.unpaidHours = response.data.unpaidHours;
					self.usedHours = response.data.usedHours;
					self.startDate = response.data.startDate;

					self.isLoading = false;
				});
			}

			self.order = function(sortBy) {
				self.reverse = (self.sortBy === sortBy) ? !self.reverse : true;
				self.sortBy = sortBy;
			};

			self.resize = function(maximize) {
				self.maximized = maximize;
			};

			self.loadGridData();
		}
	]);

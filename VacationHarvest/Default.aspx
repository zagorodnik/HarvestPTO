<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VacationHarvest._Default" %>

<%@ Import Namespace="VacationHarvest.BL" %>


<asp:Content ID="ScriptsContent" ContentPlaceHolderID="ScriptsPlaceHolder" runat="Server">
	<script type="text/javascript" src="/Scripts/Pages/Main/index.js"></script>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

	<div ng-app="ptoApp" ng-controller="gridCtrl as grid" class="pto-container">
		<div class="pto-header-container">
			<div>
				<header>
					<section class="clearfix">
						<div class="main flt-left">
							<%= FullName %>'s PTO <span class="higthligth">({{grid.hoursLeft}} h available)</span>
						</div>
						<div class="flt-right">
							Welcome, <b><%= FirstName %></b>
						</div>
					</section>
					<section class="clearfix">
						<div class="flt-left">
							Has been working at Arrow for <b>{{grid.startDate | timeDiff}}</b>
						</div>
						<div class="flt-right">
							<a href="Account/Login">Sign Out</a>
						</div>
					</section>
				</header>
			</div>
		</div>
		<div class="pto-grid-container clearfix" ng-class="grid.maximized ? 'maximized' : ''">
			<div class="pto-grid pto-panel flt-left">
				<header class="clearfix">
					<div class="column flt-left date-column">
						<a href="" ng-click="grid.order('StartDate')">Start Date</a>
						<span class="sortorder" ng-show="grid.sortBy === 'StartDate'" ng-class="{reverse:grid.reverse}"></span>
					</div>
					<div class="column flt-left date-column">
						<a ng-click="grid.order('EndDate')">End Date</a>
						<span class="sortorder" ng-show="grid.sortBy === 'EndDate'" ng-class="{reverse:grid.reverse}"></span>
					</div>
					<div class="column flt-left hours-column separator">
						<a ng-click="grid.order('UsedHours')">Used, h</a>
						<span class="sortorder" ng-show="grid.sortBy === 'UsedHours'" ng-class="{reverse:grid.reverse}"></span>
					</div>
					<div class="column flt-left comment-column separator clearfix">
						<div class="flt-left">
							<a ng-click="grid.order('Notes')">PTO Comment, Type</a>
							<span class="sortorder" ng-show="grid.sortBy === 'Notes'" ng-class="{reverse:grid.reverse}"></span>
						</div>
						<div class="flt-right filter higthligth">
							<span>Filter</span>
							<span class="sortorder"></span>
							<div class="options-container">
								<ul class="options">
									<li>
										<label>
											<input type="checkbox" ng-model="grid.filters.newMonth" />
											New month
										</label>
									</li>
									<li>
										<label>
											<input type="checkbox" ng-model="grid.filters.vacation" />
											Vacation
										</label>
									</li>
									<li>
										<label>
											<input type="checkbox" ng-model="grid.filters.sickLeave" />
											Sick leave
										</label>
									</li>
									<li>
										<label>
											<input type="checkbox" ng-model="grid.filters.unpaid" />
											Unpaid
										</label>
									</li>
								</ul>
							</div>
						</div>
					</div>
					<div class="column flt-left hours-column higthligth separator clearfix">
						<div class="flt-left">
							<a ng-click="grid.order('HoursLeft')">Balance, h</a>
							<span class="sortorder" ng-show="grid.sortBy === 'HoursLeft'" ng-class="{reverse:grid.reverse}"></span>
						</div>
						<div class="flt-right higthligth btn-container" ng-show="grid.maximized">
							<a ng-click="grid.resize(false)">
								<span class="show-button-icon"></span>
								<span>Show</span> 							
							</a>
						</div>
					</div>
				</header>
				<section class="content">
					<table style="border-collapse: collapse;">
						<tbody>
							<tr ng-repeat="item in grid.entries | orderBy:grid.sortBy:grid.reverse | byType:grid.filters" class="{{item.RecordType | recordTypeClass}} {{item.StartDate | prevYearClass}}">
								<td class="column date-column">{{item.StartDate | date: 'longDate'}}</td>
								<td class="column date-column">{{item.EndDate | date: 'longDate'}}</td>
								<td class="column hours-column">{{item.UsedHours | number:2}}</td>
								<td class="column comment-column">{{item.Notes}}</td>
								<td class="column hours-column higthligth">{{item.HoursLeft | number:2}}</td>
							</tr>
							<tbody>
					</table>
				</section>
			</div>
			<div class="pto-hints pto-panel flt-left">
				<header>
					<div class="column separator clearfix">
						<div class="flt-left">
							PTO Types Descriptions & Formula
						</div>
						<div class="flt-right higthligth btn-container">
							<a ng-click="grid.resize(true)">
								<span>Hide</span> 							
								<span class="hide-button-icon"></span>
							</a>
						</div>
					</div>
				</header>
				<section class="content">
					<article class="higthligth main">
						<p>
							Current Month <b>Vacation Balance</b> = Previous Month <b>Vacation Balance + k - Used</b>
						</p>
					</article>
					<article class="higthligth">
						<p>
							<b>k</b> = 80 h / 12 month = 6.67 (hours per month)<br />
							<b>Month Balance</b> <sub>max</sub> = 96 h<br />
							<b>Month Balance</b> <sub>min</sub> = -40 h
						</p>
						<p>
							Used Sick Leaves and Unpaid hours do not affect the Paid Leaves Balance.
							The Employee should report the unpaid and sickmess hours in Harvest,
							as "<b><% =Constants.SICK_LEAVE %></b>" and "<b><% =Constants.UNPAID %></b>" then.
						</p>
					</article>
					<article>
						<p>
							The Employee gains 6.67 hours of Paid Leave each month, that are added to his current balance.
							He is free to use those hours whenever he needs them, be it vacations, days-off etc.
							Those hours are fully reimburst by the Companny.
							The Current Month Balance can't exceed 96 hours and can't go bellow -40 hours.
						</p>
						<p>
							If the Employee reports his absence as "<b><% =Constants.SICK_LEAVE %></b>" in Harvest,
							then these used hours won't affect balance.
							Sick leaes are reimburst by the company in the amount of 50%.
							The Employee may use up to 80 hours of sick leave per year.
							The overlimiting hours should be reported as "<b><% =Constants.UNPAID %></b>"
							or otherwise will be subtracted from the Paid Leave Balance
						</p>
						<p>
							The used Unpaid hours do not affect the vacation balance if they are reported as "<b><% =Constants.UNPAID %></b>" in Harvest as well.
						</p>
					</article>

					<article class="higthligth">
						<p>
							Current Vacation Balance: <b>{{grid.hoursLeft}} h</b>
						</p>
					</article>
				</section>
			</div>
		</div>
		<div class="loading-container" ng-show="grid.isLoading">
			<div class="overlay"></div>
			<div class="loading"></div>
		</div>
	</div>

</asp:Content>


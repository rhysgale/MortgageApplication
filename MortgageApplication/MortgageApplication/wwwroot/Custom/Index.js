﻿var app = new Vue({
    el: '#main',
    data: {
        showUserInput: false,
        showProductSearch: false,
        firstName: "",
        lastName: "",
        dateOfBirth: "1900-01-01",
        emailAddress: "",
        currentUserId: "",
        price: 0,
        deposit: 0,
        banksWithProducts: ""
    },
    methods: {
        applicationStart: function () {
            this.showUserInput = true;
        },
        submitInformation: async function () {
            var model = { FirstName: firstName.value, LastName: lastName.value, DateOfBirth: dateOfBirth.value, Email: emailAddress.value };

            var options = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(model)
            };

            var response = await fetch("https://localhost:44371/api/NewUser", options);

            var data = await response.json();

            currentUserId = data.newUserId;
            this.showProductSearch = true;
            this.showUserInput = false;
        },
        fetchProducts: async function () {
            var model = { UserId: currentUserId, Deposit: parseFloat(deposit.value), HouseValue: parseFloat(price.value) };

            var options = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(model)
            };

            var response = await fetch("https://localhost:44371/api/GetEligibleProducts", options);

            var data = await response.json();

            this.banksWithProducts = data.banksWithProducts;
        }
    }
});
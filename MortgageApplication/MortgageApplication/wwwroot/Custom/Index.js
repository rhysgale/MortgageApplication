var app = new Vue({
    el: '#main',
    data: {
        showUserInput: false,
        firstName: "",
        lastName: "",
        dateOfBirth: "",
        emailAddress: ""
    },
    methods: {
        applicationStart: function () {
            this.showUserInput = true;
        },
        submitInformation: function () {

        }
    }
});
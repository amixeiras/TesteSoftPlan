// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
Inputmask.extendAliases({
    'integerline': {
      autoUnmask: true,
      mask: "99",
      oncomplete: function() {
       // do something
      },
      onincomplete: function() {
       // do something
      }
    },
      'decimalLine': {
        prefix: "",
        groupSeparator: ".",
        radixPoint: ",",
        alias: "numeric",
        placeholder: "0",
        autoGroup: !0,
        digits: 2,
        digitsOptional: !1,
        clearMaskOnLostFocus: !1,
        rightAlign: true,
        oncomplete: function() {
         // do something
        },
        onincomplete: function() {
         // do something
        }
    }
});

$(function(){
  $('[data-inputmask]').inputmask();
})



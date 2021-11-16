// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(() => {
    if (!localStorage.pureJavaScriptCookies) {
      document.querySelector(".box-cookies").classList.remove('hide');
    }
    
    const acceptCookies = () => {
      document.querySelector(".box-cookies").classList.add('hide');
      localStorage.setItem("pureJavaScriptCookies", "accept");
    };
    
    const btnCookies = document.querySelector(".btn-cookies");
    
    btnCookies.addEventListener('click', acceptCookies);
  })();

  (function(d, w, c) {
    w.ChatraID = 'z26vLtQKgM7wYJxjf';
    var s = d.createElement('script');
    w[c] = w[c] || function() {
        (w[c].q = w[c].q || []).push(arguments);
    };
    s.async = true;
    s.src = 'https://call.chatra.io/chatra.js';
    if (d.head) d.head.appendChild(s);
})(document, window, 'Chatra');

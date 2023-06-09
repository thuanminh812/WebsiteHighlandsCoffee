<template>
    <footer>
    <div class="rounded-social-buttons">
                      <a class="social-button facebook" href="https://www.facebook.com/highlandscoffeevietnam/" target="_blank"><i class="fab fa-facebook-f"></i></a>
                      <a class="social-button youtube" href="https://www.youtube.com/channel/UCHEqa2uTf8uXrGWrnU3ThgA" target="_blank"><i class="fab fa-youtube"></i></a>
                      <a class="social-button instagram" href="https://www.instagram.com/highlandscoffeevietnam/" target="_blank"><i class="fab fa-instagram"></i></a>
                      <p class="text-white">@2018 Highlands Coffee. All rights reserved</p>
  <p class="text-white"><i class="far fa-envelope"></i> customerservice@highlandscoffee.com.vn</p>
                  </div>
                  
  </footer>
  </template>
  
  <script>
  export default {
  
  }
  </script>
  
  <style scoped>
  body {
      background: #D0D8DB;
  }
  
  .welcome{
    text-align: center;
  }
  h3{
    position: relative;
    color: #000;
  }
  #scroll{
              height:302px;
              overflow-x:hidden;
              overflow-y:auto;
  }
  #hover1:hover{
    color: #bb0000;
  }
  .imgcar{
   width: 100%;
   border-radius: 20px;
  }
  #hover {
    --c:linear-gradient(#e1d2d2 0 0); /* update the color here */
    
    padding-bottom: .15em;
    background: var(--c), var(--c);
    background-size: .3em .1em;
    background-position:50% 100%;
    background-repeat: no-repeat;
    transition: .3s linear, background-size .3s .2s linear;
  }
  #hover:hover {
    background-size: 40% .1em;
    background-position: 10% 100%, 90% 100%;
  }
  
  #title{
    font-family: 'Courier New', Courier, monospace;
        font-size: 30px;
        font-weight: bold;
        color: #555555;
  }
  .card-image{
    width: 400px;
    height: 220px;
    object-fit: cover;
  }
  footer{
    background-color: #000000D9; 
  }
  #card-image1{
    width: 100%;
    height: 100px;
  }
  a{
    font-family: sans-serif;
    font-weight: bold;
    color: white;
  }
  a:hover{
    text-decoration: none;
    color: white;
  }
  textarea {
      resize: none;
  }
  .text {
    color: white;
    font-size: 20px;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    -ms-transform: translate(-50%, -50%);
    white-space: nowrap;
  }
  
  .svg-inline--fa {
    vertical-align: -0.200em;
  }
  
  .rounded-social-buttons {
    text-align: center;
    padding: 10px;
  }
  .rounded-social-buttons .social-button {
    display: inline-block;
    position: relative;
    cursor: pointer;
    width: 3.125rem;
    height: 3.125rem;
    border: 0.125rem solid transparent;
    padding: 0;
    text-decoration: none;
    text-align: center;
    color: #fefefe;
    font-size: 1.5625rem;
    font-weight: normal;
    line-height: 2em;
    border-radius: 1.6875rem;
    transition: all 0.5s ease;
    margin-right: 0.25rem;
    margin-bottom: 0.25rem;
  }
  
  .rounded-social-buttons .social-button:hover, .rounded-social-buttons .social-button:focus {
    -webkit-transform: rotate(360deg);
        -ms-transform: rotate(360deg);
            transform: rotate(360deg);
  }
  
  .rounded-social-buttons .fa-twitter, .fa-facebook-f, .fa-linkedin, .fa-youtube, .fa-instagram {
    font-size: 25px;
  }
  
  .rounded-social-buttons .social-button.facebook {
    background: #3b5998;
  }
  
  .rounded-social-buttons .social-button.facebook:hover, .rounded-social-buttons .social-button.facebook:focus {
    color: #3b5998;
    background: #fefefe;
    border-color: #3b5998;
  }
  
  .rounded-social-buttons .social-button.twitter {
    background: #55acee;
  }
  
  .rounded-social-buttons .social-button.twitter:hover, .rounded-social-buttons .social-button.twitter:focus {
    color: #55acee;
    background: #fefefe;
    border-color: #55acee;
  }
  
  .rounded-social-buttons .social-button.linkedin {
    background: #007bb5;
  }
  
  .rounded-social-buttons .social-button.linkedin:hover, .rounded-social-buttons .social-button.linkedin:focus {
    color: #007bb5;
    background: #fefefe;
    border-color: #007bb5;
  }
  
  .rounded-social-buttons .social-button.youtube {
    background: #bb0000;
  }
  
  .rounded-social-buttons .social-button.youtube:hover, .rounded-social-buttons .social-button.youtube:focus {
    color: #bb0000;
    background: #fefefe;
    border-color: #bb0000;
  }
  
  .rounded-social-buttons .social-button.instagram {
    background: #125688;
  }
  
  .rounded-social-buttons .social-button.instagram:hover, .rounded-social-buttons .social-button.instagram:focus {
    color: #125688;
    background: #fefefe;
    border-color: #125688;
  }
  p{
    font-family: sans-serif;
    color:#555555;
    text-align: center;
    
  }
  #menu1{
    height: 350px;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    display: flex;
  }
  #menu2{
    height: 350px;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    display: flex;
  }
  </style>
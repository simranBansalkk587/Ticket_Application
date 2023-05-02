// import { Injectable } from '@angular/core';


// import * as nodemailer from 'nodemailer';


// @Injectable({
//   providedIn: 'root'
// })
// export class MailServiceService {

//   constructor() { }
//   sendEmail(to: string, subject: string, html: string) {
//     const transporter = nodemailer.createTransport({
//       service: 'gmail',
//       auth: {
//         user: 'YOUR_GMAIL_EMAIL',
//         pass: 'YOUR_GMAIL_PASSWORD'
//       }
//     });

//     const mailOptions = {
//       from: 'YOUR_GMAIL_EMAIL',
//       to: to,
//       subject: subject,
//       html: html
//     };

//     const result =  transporter.sendMail(mailOptions);

//     return result;
//   }
// }


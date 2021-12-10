using System;
using SecurityQuestions.Models;
using SecurityQuestions.Repositories.Interfaces;
using SecurityQuestions.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace SecurityQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            string UserName = string.Empty;
            string QuestionAnswer = string.Empty;
            bool endApp = false;

            var collection = new ServiceCollection();

            collection
                .AddDbContext<EFContext>()
                .AddScoped<IUserSecurityQuestionRepository, UserSecurityQuestionRepository>()
                .AddScoped<ISecurityQuestionRepository, SecurityQuestionRepository>()
                .AddScoped<IUserRepository, UserRepository>();

            var service = collection.BuildServiceProvider();
            var _userrepo = service.GetService<IUserRepository>();
            var _securityQuestionrepo = service.GetService<ISecurityQuestionRepository>();
            var _userSecurityQuestionrepo = service.GetService<IUserSecurityQuestionRepository>();

            try
            {
                while (!endApp)
                {
                    Console.WriteLine("Hi, what is your name?");
                    UserName = Convert.ToString(Console.ReadLine());

                    User user = _userrepo.GetByName(UserName);

                    if (user == null) // User does not exist
                    {
                        Console.WriteLine("User does not exist,try another User Name");
                    }
                    else // User exist
                    {
                        List<UserSecurityQuestion> UserSecurityQuestions = (List<UserSecurityQuestion>)_userSecurityQuestionrepo.GetByUserID(user.UserID);
                        if (UserSecurityQuestions.Count == 0) // User has no stored security questions 
                        {
                            // Add logging later
                            Console.WriteLine("Would you like to store answers to security questions (Y/N)?");
                            QuestionAnswer = Convert.ToString(Console.ReadLine());
                        
                            if (QuestionAnswer.ToUpper() == "Y")
                            {
                                Store((List<SecurityQuestion>)_securityQuestionrepo.GetAll(), user.UserID, collection);
                            }
                            else
                            {
                                Console.WriteLine("user declined to store");
                            }
                        }
                        else // User has  stored security questions 
                        {
                            // Add logging later
                            Console.WriteLine("Do you want to answer a security question (Y/N)?");
                            QuestionAnswer = Convert.ToString(Console.ReadLine());
                        
                            if (QuestionAnswer.ToUpper() == "Y") //present the “Answer” flow
                            {
                                // Add logging later
                                Answer((List<UserSecurityQuestion>)_userSecurityQuestionrepo.GetAll(),  collection);
                            }
                            else  //re-do answers through the “Store” flow
                            {
                                // Add logging later
                                Store((List<SecurityQuestion>)_securityQuestionrepo.GetAll(), user.UserID, collection);
                            }

                        }
                        Console.WriteLine("\n"); 

                    }

                    // Wait for the user to respond before closing.
                    Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                    if (Console.ReadLine() == "n") endApp = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: {0}", ex);
            }
            return;
        }
        
        static void Store(List<SecurityQuestion> securityQuestions,int userID, ServiceCollection collection)
        {
            string Answer = string.Empty;
            var service = collection.BuildServiceProvider();
            var _userSecurityQuestionrepo = service.GetService<IUserSecurityQuestionRepository>();
            int userAnswers = 0;
            
            //Prompt with Security questions to store answers
            foreach (SecurityQuestion securityQuestion in securityQuestions)
            {

                Console.WriteLine(securityQuestion.Description);
                Answer = Convert.ToString(Console.ReadLine());
                

                UserSecurityQuestion userSecurityQuestion = _userSecurityQuestionrepo.GetByUserIDAndSecurityQuestionID(userID, securityQuestion.SecurityQuestionID);

                if (userSecurityQuestion != null) // if User security question exist, update answer
                {
                    userSecurityQuestion.SecurityQuestionAnswer = Answer;

                    _userSecurityQuestionrepo.Update(userSecurityQuestion);
                }
                else  // if User security question does not exist, Insert user security Question and answer
                {
                    userSecurityQuestion = new UserSecurityQuestion();

                    userSecurityQuestion.UserID = userID;
                    userSecurityQuestion.SecurityQuestionID = securityQuestion.SecurityQuestionID;
                    userSecurityQuestion.SecurityQuestionAnswer = Answer;

                    _userSecurityQuestionrepo.Insert(userSecurityQuestion);
                }
                userAnswers = userAnswers + 1;

                if (userAnswers == 3) // 3 answers choosen
                {
                    _userSecurityQuestionrepo.Save();
                    Console.WriteLine("you have answered 3 Questions, Done");
                    break;
                }
            }
            
        }

        static void Answer(List<UserSecurityQuestion> userSecurityQuestions, ServiceCollection collection)
        {
            var service = collection.BuildServiceProvider();
            var _securityQuestionrepo = service.GetService<ISecurityQuestionRepository>();
            string Answer = string.Empty;
            int numberofQuestions = 0;

            // Display stored security questions
            foreach (UserSecurityQuestion userSecurityQuestion in userSecurityQuestions)
            {
                SecurityQuestion securityQuestion = _securityQuestionrepo.GetById(userSecurityQuestion.SecurityQuestionID);
                Console.WriteLine(securityQuestion.Description);
                Answer = Convert.ToString(Console.ReadLine());
                numberofQuestions = numberofQuestions + 1;

                if (Answer.ToUpper() != userSecurityQuestion.SecurityQuestionAnswer.ToUpper())
                {
                    Console.WriteLine("Incorrect Answer, try again");
                    if (userSecurityQuestions.Count == numberofQuestions) 
                    {
                        Console.WriteLine("You have run out of questions");
                    }
                }
                else
                {
                    Console.WriteLine("Congratulates,Correct Answer");
                }

            }
        }
    }
}

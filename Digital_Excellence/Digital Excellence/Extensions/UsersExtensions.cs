﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models.Defaults;

namespace Digital_Excellence.Extensions
{
	internal static class UsersExtensions
	{
		/// <summary>
		/// Gets the student identifier asynchronous.
		/// </summary>
		/// <param name="claimsPrincipal">The claims principal.</param>
		/// <param name="actionContext">The action context.</param>
		/// <returns></returns>
		/// <exception cref="Exception">The back-end header isn't added!</exception>
		/// <exception cref="NotSupportedException">The jwt doesn't have a sub</exception>
		/// <exception cref="System.Exception">The back-end header isn't added!</exception>
		public static int GetStudentId(this ClaimsPrincipal claimsPrincipal, HttpContext actionContext)
		{
			int studentId;

			if (claimsPrincipal.Identities.Any(i => !i.IsAuthenticated))
			{
				throw new Exception("User is not authenticated!");
			}

			if (claimsPrincipal.IsInRole(Defaults.Roles.BackendApplication))
			{
				string studentIdHeader = actionContext.Request.Headers.SingleOrDefault(h => h.Key == "StudentId").Value.FirstOrDefault();

				if (string.IsNullOrWhiteSpace(studentIdHeader))
				{
					throw new Exception("The back-end header isn't added!");
				}

				studentId = Convert.ToInt32(studentIdHeader);
			}
			else
			{
				string sub = claimsPrincipal.Claims.FirstOrDefault(c => c.Type.Equals("sub")).Value;
				if (sub == null)
				{
					throw new NotSupportedException("The jwt doesn't have a sub");
				}

				return Convert.ToInt32(sub);
			}

			return studentId;
		}

		/// <summary>
		/// Gets the name of the student.
		/// </summary>
		/// <param name="iUserPrincipal">The i user principal.</param>
		/// <returns></returns>
		public static string GetStudentName(this IPrincipal iUserPrincipal)
		{
			return iUserPrincipal.Identity.Name;
			//return Student.ConvertStudentPcnToCompatibleVersion(iUserPrincipal.Identity.Name);
		}
	}
}

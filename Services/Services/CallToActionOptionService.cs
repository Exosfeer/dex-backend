/*
* Digital Excellence Copyright (C) 2020 Brend Smits
* 
* This program is free software: you can redistribute it and/or modify 
* it under the terms of the GNU Lesser General Public License as published 
* by the Free Software Foundation version 3 of the License.
* 
* This program is distributed in the hope that it will be useful, 
* but WITHOUT ANY WARRANTY; without even the implied warranty 
* of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
* See the GNU Lesser General Public License for more details.
* 
* You can find a copy of the GNU Lesser General Public License 
* along with this program, in the LICENSE.md file in the root project directory.
* If not, see https://www.gnu.org/licenses/lgpl-3.0.txt
*/

using Models;
using Repositories;
using Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services
{

    /// <summary>
    ///     This is the interface for the call to action option service
    /// </summary>
    public interface ICallToActionOptionService : IService<CallToActionOption>
    {

        /// <summary>
        ///     This method gets all the call to action options with the specified type asynchronous.
        /// </summary>
        /// <returns>This method returns a list of call to action options with the specified type id.</returns>
        Task<IEnumerable<CallToActionOption>> GetCallToActionOptionsFromTypeAsync(string typeName);

        /// <summary>
        ///     This method gets all the call to action options with the specified value asynchronous.
        /// </summary>
        /// <returns>This method returns a list of call to action options with the specified value id.</returns>
        Task<IEnumerable<CallToActionOption>> GetCallToActionOptionFromValueAsync(string value);

    }

    /// <summary>
    ///     This is the call to action option service
    /// </summary>
    public class CallToActionOptionService : Service<CallToActionOption>, ICallToActionOptionService
    {

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmbedService" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CallToActionOptionService(ICallToActionOptionRepository repository) : base(repository) { }

        /// <summary>
        ///     Gets the repository.
        /// </summary>
        protected new ICallToActionOptionRepository Repository => (ICallToActionOptionRepository) base.Repository;

        /// <summary>
        ///     This is the method which gets all call to actions options by type asynchronous
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns>IEnumerable of call to action options</returns>
        public async Task<IEnumerable<CallToActionOption>> GetCallToActionOptionsFromTypeAsync(string typeName)
        {
            return await Repository.GetCallToActionOptionsFromTypeAsync(typeName);
        }

        /// <summary>
        ///     This is the method which gets all call to action options by value asynchronous
        /// </summary>
        /// <param name="value"></param>
        /// <returns>IEnumerable of call to action options</returns>
        public async Task<IEnumerable<CallToActionOption>> GetCallToActionOptionFromValueAsync(string value)
        {
            return await Repository.GetCallToActionOptionFromValueAsync(value);
        }

    }

}

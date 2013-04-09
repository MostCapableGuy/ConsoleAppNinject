/*
Copyright (c) 2013 
# Ulf Tomas Bjorklund
# http://average-uffe.blogspot.com/
# http://twitter.com/ulfbjo

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ConsoleAppNinject.Core.Model;

namespace ConsoleAppNinject.Core.ViewModel
{
    [Serializable]
    [DataContract]
    public abstract class BaseViewModel
    {
        /// <summary>
        /// The primary key for all entities...
        /// </summary>
        [DataMember]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The time when the entity was first created.
        /// </summary>
        [DataMember]
        public string Created { get; set; }

        /// <summary>
        /// The time when the entity was last saved/updated.
        /// </summary>
        [DataMember]
        public string Updated { get; set; }

        protected BaseViewModel(PersistentEntity entity)
        {
            this.Id = entity.Id;
            this.Created = entity.Created;
            this.Updated = entity.Updated;
        }

        protected BaseViewModel() { }
    }
}

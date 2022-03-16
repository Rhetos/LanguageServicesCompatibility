/*
    Copyright (C) 2014 Omega software d.o.o.

    This file is part of Rhetos.

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as
    published by the Free Software Foundation, either version 3 of the
    License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using Rhetos.Dsl;
using Rhetos.Utilities;
using System;
using System.Collections.Generic;

namespace Rhetos.LanguageServicesCompatibility
{
    /// <summary>
    /// In Rhetos 5, ConceptMember inherits ConceptMemberBase.
    /// This class converts ConceptMember from Rhetos 4 to ConceptMember from Rhetos 5.
    /// </summary>
    public static class ConceptMemberAdapter
    {
        public static ConceptMember5 ToConceptMember5(ConceptMember conceptMember, int index)
        {
            var result = new ConceptMember5
            {
                ValueType = conceptMember.ValueType,
                Index = index,
                Name = conceptMember.Name,
                IsConceptInfo = conceptMember.IsConceptInfo,
                IsKey = conceptMember.IsKey,
                IsParentNested = conceptMember.IsParentNested,
                SortOrder1 = conceptMember.SortOrder1,
                SortOrder2 = conceptMember.SortOrder2,
                IsDerived = conceptMember.IsDerived,
                IsStringType = conceptMember.IsStringType,
                IsConceptInfoInterface = conceptMember.ValueType == typeof(IConceptInfo),
                IsParsable = conceptMember.IsParsable
            };

            return result;
        }
    }
}

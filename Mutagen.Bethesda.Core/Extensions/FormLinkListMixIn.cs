﻿using Noggog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mutagen.Bethesda
{
    public static class FormLinkListMixIn
    {
        public static void Add<TMajor>(this IList<IFormLinkGetter<TMajor>> list, FormKey formKey)
            where TMajor : class, IMajorRecordCommonGetter
        {
            list.Add(new FormLink<TMajor>(formKey));
        }

        public static void AddRange<TMajor>(this IList<IFormLinkGetter<TMajor>> list, IEnumerable<FormKey> formKeys)
            where TMajor : class, IMajorRecordCommonGetter
        {
            list.AddRange(formKeys.Select(formKey => (IFormLinkGetter<TMajor>)new FormLink<TMajor>(formKey)));
        }

        public static void Remove<TMajor>(this IList<IFormLinkGetter<TMajor>> list, FormKey formKey)
            where TMajor : class, IMajorRecordCommonGetter
        {
            list.Remove(new FormLink<TMajor>(formKey));
        }

        public static void Remove<TMajor>(this IList<IFormLinkGetter<TMajor>> list, IEnumerable<FormKey> formKeys)
            where TMajor : class, IMajorRecordCommonGetter
        {
            list.Remove(formKeys.Select(formKey => (IFormLinkGetter<TMajor>)new FormLink<TMajor>(formKey)));
        }

        public static void Add<TMajor, TMajorAdd>(this IList<IFormLinkGetter<TMajor>> list, TMajorAdd rec)
            where TMajor : class, IMajorRecordCommonGetter
            where TMajorAdd : class, TMajor
        {
            list.Add(new FormLink<TMajor>(rec.FormKey));
        }

        public static void AddRange<TMajor, TMajorAdd>(this IList<IFormLinkGetter<TMajor>> list, IEnumerable<TMajorAdd> recs)
            where TMajor : class, IMajorRecordCommonGetter
            where TMajorAdd : class, TMajor
        {
            list.AddRange(recs.Select(rec => rec.FormKey));
        }

        public static void Remove<TMajor, TMajorRem>(this IList<IFormLinkGetter<TMajor>> list, TMajorRem rec)
            where TMajor : class, IMajorRecordCommonGetter
            where TMajorRem : class, TMajor
        {
            list.Remove(new FormLink<TMajor>(rec.FormKey));
        }

        public static void Remove<TMajor, TMajorRem>(this IList<IFormLinkGetter<TMajor>> list, IEnumerable<TMajorRem> recs)
            where TMajor : class, IMajorRecordCommonGetter
            where TMajorRem : class, TMajor
        {
            list.Remove(recs.Select(rec => rec.FormKey));
        }

        public static bool Contains<TMajor>(this IReadOnlyList<IFormLinkGetter<TMajor>> list, FormKey formKey)
            where TMajor : class, IMajorRecordCommonGetter
        {
            return list.Any(f => f.FormKey == formKey);
        }

        public static bool Contains<TMajor, TMajorRem>(this IReadOnlyList<IFormLinkGetter<TMajor>> list, TMajorRem rec)
            where TMajor : class, IMajorRecordCommonGetter
            where TMajorRem : class, TMajor
        {
            return list.Contains(rec.FormKey);
        }
    }
}

export const transformUrl = (url: string, stringReplacer: any): string => {
    const isFrontEndRouting = url.indexOf('/:') !== -1;
    Object.keys(stringReplacer).forEach(key => {
        url = url.replace(isFrontEndRouting ? `:${key}` : `{{${key}}}`, stringReplacer[key]);
    });
    return url;
}
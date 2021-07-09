export const dateFormatterDe = new Intl.DateTimeFormat('de-DE', {
    hour12: false,
    day: 'numeric',
    year: 'numeric',
    month: 'numeric',
});

export const dateFormatterEn = new Intl.DateTimeFormat('en-US', {
    hour12: true,
    day: 'numeric',
    year: 'numeric',
    month: 'numeric',
});
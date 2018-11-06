export interface PeriodicElement {
    id: string,
    name: string;
    position: number;
    weight: number;
    symbol: string;
    isotopes: Isotope[];
}

export interface Isotope {
    name: string;
}
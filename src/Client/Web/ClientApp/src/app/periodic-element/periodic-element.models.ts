export interface PeriodicElementHeader {
    id: string,
    name: string;
    position: number;
    weight: number;
    symbol: string;
}

export interface PeriodicElement extends PeriodicElementHeader {
    isotopes: Isotope[];
}

export interface Isotope {
    name: string;
}

export interface PeriodicElementForEdit {
    periodicElement: PeriodicElement;
}